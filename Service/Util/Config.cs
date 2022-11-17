using System.Text.Json.Nodes;
using Dnsk.Common;
using Newtonsoft.Json;

namespace Dnsk.Service.Util;

public class ServerConfig
{
    public string Listen { get; init; }
}
public class DbConfig
{
    public string Connection { get; init; }
}

public class SessionConfig
{
    public string[] SignatureKeys { get; init; }
}

public static class Config
{
    public static ServerConfig Server { get; }
    public static DbConfig Db { get; }
    public static SessionConfig Session { get; }

    static Config()
    {
        var r = JsonConvert.DeserializeObject<Raw>(File.ReadAllText(Path.Join(Directory.GetCurrentDirectory(), "config.json"))).NotNull();
        Server = r.Server;
        Db = r.Db;
        Session = r.Session;
    }
    
    public class Raw
    {
        public ServerConfig Server { get; init; }
        public DbConfig Db { get; init; }
        public SessionConfig Session { get; init; }
    }
}