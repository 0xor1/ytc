using Dnsk.Common;
using Grpc.Core;
using MessagePack;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Dnsk.Service.Util;

[MessagePackObject]
public record Session
{
    [Key(0)]
    public string Id { get; init; }
    
    [Key(1)]
    public DateTime? AuthedOn { get; init; }

    [IgnoreMember]
    public bool IsAuthed => AuthedOn.IsntNull();
    
    [IgnoreMember]
    public bool IsAnon => !IsAuthed;
}

public class SessionManager: ISessionManager
{
    private const string SessionName = "dnsk";
    private Session? _cache { get; set; }

    public Session Get(ServerCallContext stx)
    {
        if (_cache.IsNull())
        {
            _cache = GetCookie(stx);
        }
        return _cache;
    }

    public Session Login(ServerCallContext stx)
    {
        var ses = new Session()
        {
            Id = Ulid.NewUlid().ToBase64(),
            AuthedOn = DateTime.UtcNow
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
                Id = Ulid.NewUlid().ToBase64(),
                AuthedOn = null
            };
            SetCookie(stx, ses);
            return ses;
        }
        else
        {
            // there is a session so lets get it from the cookie
            var bytes = Convert.FromBase64String(c);
            var ses = MessagePackSerializer.Deserialize<Session>(bytes);
            return ses;
        }
    }
    
    private static void SetCookie(ServerCallContext stx, Session ses)
    {
        var bytes = MessagePackSerializer.Serialize(ses);
        // use messagepack to convert session to bytes
        // then sign the bytes, then encrypt the bytes
        // then write the bytes in base64 format to the session cookie
        stx.GetHttpContext().Response.Cookies.Append(SessionName, Convert.ToBase64String(bytes), new CookieOptions()
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
}

public interface ISessionManager
{
    public Session Get(ServerCallContext stx);
    public Session Login(ServerCallContext stx);
    public Session Logout(ServerCallContext stx);
}