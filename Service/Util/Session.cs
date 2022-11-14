using Dnsk.Common;
using Grpc.Core;
using MessagePack;
using Microsoft.AspNetCore.Http;

namespace Dnsk.Service.Util;

public static class ServerCallContextExtensions
{
    private const string SessionName = "dnsk";
    
    public static Session GetSession(this ServerCallContext stx)
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
            stx.SetSession(ses);
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

    public static void SetSession(this ServerCallContext stx, Session ses)
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

    public static void Logout(this ServerCallContext stx)
    {
        stx.GetHttpContext().Response.Cookies.Delete(SessionName);
        // use GetSession to automatically create a new anon session
        GetSession(stx);
    }

}
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