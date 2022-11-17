using System.Collections.Immutable;
using System.Security;
using System.Security.Cryptography;
using Dnsk.Common;
using Grpc.Core;
using MessagePack;
using Microsoft.AspNetCore.Http;

namespace Dnsk.Service.Util;

[MessagePackObject]
public record Session
{
    [Key(0)]
    public string Id { get; init; }
    
    [Key(1)]
    public DateTime? StartedOn { get; init; }
    
    [Key(2)]
    public bool IsAuthed { get; init; }

    [IgnoreMember]
    public bool IsAnon => !IsAuthed;
}

public class SessionManager: ISessionManager
{
    private const string SessionName = "dnsk";
    private static readonly byte[][] SignatureKeys;

    static SessionManager()
    {
        SignatureKeys = Config.Session.SignatureKeys.Select(x => Base64.UrlDecode(x)).ToArray();
        if (SignatureKeys.Count(x => x.Length != 64) > 0)
        {
            throw new InvalidDataException("config: all session signature keys must be 64 bytes long");
        }

        if (SignatureKeys.Length == 0)
        {
            throw new InvalidDataException("config: there must be at least 1 session signature key");
        }
    }
    
    private Session? _cache { get; set; }

    public Session Get(ServerCallContext stx)
    {
        if (_cache.IsNull())
        {
            _cache = GetCookie(stx);
        }
        return _cache;
    }

    public Session Login(ServerCallContext stx, string userId)
    {
        var ses = new Session()
        {
            Id = userId,
            StartedOn = DateTime.UtcNow,
            IsAuthed = true
        };
        _cache = ses;
        SetCookie(stx, ses);
        return ses;
    }

    public Session Logout(ServerCallContext stx)
    {
        DeleteCookie(stx);
        // generate new anon session
        return Get(stx);
    }
    
    private static Session GetCookie(ServerCallContext stx)
    {
        var htx = stx.GetHttpContext();
        var c = htx.Request.Cookies[SessionName];
        if (c.IsNull())
        {
            var ses = new Session()
            {
                Id = Id.New(),
                StartedOn = DateTime.UtcNow,
                IsAuthed = false
            };
            SetCookie(stx, ses);
            return ses;
        }
        else
        {
            // there is a session so lets get it from the cookie
            var signedSessionBytes = Base64.UrlDecode(c);
            var signedSes = MessagePackSerializer.Deserialize<SignedSession>(signedSessionBytes);
            var i = 0;
            foreach (var signatureKey in SignatureKeys)
            {
                using (var hmac = new HMACSHA256(signatureKey))
                {
                    var sesSig = hmac.ComputeHash(signedSes.Session);
                    if (sesSig.SequenceEqual(signedSes.Signature))
                    {
                        var ses = MessagePackSerializer.Deserialize<Session>(signedSes.Session);
                        if (i > 0)
                        {
                            // if it wasnt signed using the latest key, resign the cookie using the latest key
                            SetCookie(stx, ses);
                        }
                        return ses;
                    }
                    i++;
                }
            }
            throw new SecurityException("Session signature verification failed");
        }
    }
    
    private static void SetCookie(ServerCallContext stx, Session ses)
    {
        // turn session into bytes
        var sesBytes = MessagePackSerializer.Serialize(ses);
        // sign the session
        byte[] sesSig;
        using (var hmac = new HMACSHA256(SignatureKeys.First()))
        {
            sesSig = hmac.ComputeHash(sesBytes);
        }
        // create the cookie value with the session and signature
        var signedSes = new SignedSession()
        {
            Session = sesBytes,
            Signature = sesSig
        };
        // get final cookie bytes
        var cookieBytes = MessagePackSerializer.Serialize(signedSes);
        // create cookie
        stx.GetHttpContext().Response.Cookies.Append(SessionName, Base64.UrlEncode(cookieBytes), new CookieOptions()
        {
            Secure = true,
            HttpOnly = true,
            IsEssential = true,
            SameSite = SameSiteMode.Strict
        });
    }
    private static void DeleteCookie(ServerCallContext stx)
    {
        stx.GetHttpContext().Response.Cookies.Delete(SessionName);
    }

    [MessagePackObject]
    public record SignedSession
    {
        [Key(0)] 
        public byte[] Session { get; init; }
        [Key(1)] 
        public byte[] Signature { get; init; }
    }
}

public interface ISessionManager
{
    public Session Get(ServerCallContext stx);
    public Session Login(ServerCallContext stx, string userId);
    public Session Logout(ServerCallContext stx);
}