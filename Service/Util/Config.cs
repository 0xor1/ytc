using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace Dnsk.Service.Util;

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
    public static DbConfig Db { get; }
    public static SessionConfig Session { get; }

    static Config()
    {
        var r = JsonConvert.DeserializeObject<Raw>(File.ReadAllText(Path.Join(Directory.GetCurrentDirectory(), "config.json")));
        Db = r.Db;
        Session = r.Session;
    }
    
    public class Raw
    {
        public DbConfig Db { get; init; }
        public SessionConfig Session { get; init; }
    }
}