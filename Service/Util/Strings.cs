namespace Dnsk.Service.Util;

public static class Strings
{
    public const string Default = "en";
    
    public static string Get(string lang, string key)
    {
        Error.If(!Library.ContainsKey(lang), $"Strings doesnt contain lang {lang}");
        Error.If(!Library[lang].ContainsKey(key), $"Strings doesnt contain key: {key} for lang: {lang}");
        return Library[lang][key];
    }
    
    public static bool TryGet(string lang, string key, out string res)
    {
        res = "";
        if (!Library.ContainsKey(lang))
        {
            return false;
        }

        if (!Library[lang].ContainsKey(key))
        {
            return false;
        }
        res = Library[lang][key];
        return true;
    }
    
    public static string GetOr(string lang, string key, string def)
    {
        if (!Library.ContainsKey(lang))
        {
            return def;
        }

        if (!Library[lang].ContainsKey(key))
        {
            return def;
        }

        return Library[lang][key];
    }
    
    public static string GetOrAddress(string lang, string key)
    {
        if (!Library.ContainsKey(lang) || !Library[lang].ContainsKey(key))
        {
            return $"{lang}:{key}";
        }

        return Library[lang][key];
    }

    public static string BestLang(string acceptLangsHeader)
    {
        var langs = acceptLangsHeader.Replace(" ", "").Split(",");
        // direct matches
        // this is commented out as presently I haven't created any specific region languages, there's just base languages
        // like en, es, fr, de, nothing specific like en-GB, en-US etc, uncomment if/when more specific options are added
        // foreach (var lang in langs)
        // {
        //     if (Library.ContainsKey(lang))
        //     {
        //         return lang;
        //     }
        // }
        // root match
        foreach (var lang in langs)
        {
            var root = lang.Split("-").First();
            if (Library.ContainsKey(root))
            {
                return root;
            }
        }
        return Default;
    }

    public static readonly IReadOnlyDictionary<string, string> English = new Dictionary<string, string>()
    {
        { "str1", "yolo son" }
    };

    public static readonly IReadOnlyDictionary<string, string> Spanish = new Dictionary<string, string>()
    {
        { "str1", "yolo hijo" }
    };

    public static readonly IReadOnlyDictionary<string, string> French = new Dictionary<string, string>()
    {
        { "str1", "yolo fils" }
    };

    public static readonly IReadOnlyDictionary<string, string> German = new Dictionary<string, string>()
    {
        { "str1", "yolo sohn" }
    };

    public static readonly IReadOnlyDictionary<string, string> Italian = new Dictionary<string, string>()
    {
        { "str1", "yolo figlio" }
    };
    
    public static readonly IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Library =
        new Dictionary<string, IReadOnlyDictionary<string, string>>()
        {
            {
                Default, 
                English
            },
            {
                "es", 
                Spanish
            },
            {
                "fr", 
                French
            },
            {
                "de", 
                German
            },
            {
                "it", 
                Italian
            }
        };
}