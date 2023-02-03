using Common;
using Fluid;

namespace Dnsk.I18n;

public record Lang(string Code, string NativeName)
{
    public override string ToString() => $"{Code} - {NativeName}";
}

public record DateTimeFmt(string Value)
{
    private static readonly DateTime dt = new DateTime(2022, 3, 28, 16, 5, 1);
    public override string ToString() => dt.ToString(Value);
}
public static partial class Strings
{
    public static readonly FluidParser Parser = new ();
    public const string EN = "en";
    public const string ES = "es";
    public const string FR = "fr";
    public const string DE = "de";
    public const string IT = "it";
    public const string DefaultLang = EN;

    public static readonly IReadOnlyList<Lang> SupportedLangs = new List<Lang>()
        { new(EN, "English"), new(ES, "Español"), new(FR, "Français"), new (DE, "Deutsch"), new (IT, "Italiano") };

    public static readonly IReadOnlyList<DateTimeFmt> SupportedDateFmts = new List<DateTimeFmt>()
        { new("yyyy-MM-dd"), new("dd-MM-yyyy"), new("MM-dd-yyyy") };

    public static string DefaultDateFmt => SupportedDateFmts.First().Value;
    
    public static readonly IReadOnlyList<DateTimeFmt> SupportedTimeFmts = new List<DateTimeFmt>()
        { new("HH:mm"), new("hh:mm") };
    public static string DefaultTimeFmt => SupportedTimeFmts.First().Value;
        

    public static string Get(string lang, string key, object? model = null)
    {
        Throw.DataIf(!Library.ContainsKey(lang), $"Strings doesnt contain lang {lang}");
        Throw.DataIf(!Library[lang].ContainsKey(key), $"Strings doesnt contain key: {key} for lang: {lang}");
        return Library[lang][key].RenderWithModel(model);
    }

    private static string RenderWithModel(this IFluidTemplate tpl, object? model)
    {
        if (model == null)
        {
            return tpl.Render();
        }
        return tpl.Render(new TemplateContext(model));
    }
    
    public static bool TryGet(string lang, string key, out string res, object? model = null)
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
        res = Library[lang][key].RenderWithModel(model);
        return true;
    }
    
    public static string GetOr(string lang, string key, string def, object? model = null)
    {
        if (!Library.ContainsKey(lang))
        {
            return def;
        }

        if (!Library[lang].ContainsKey(key))
        {
            return def;
        }

        return Library[lang][key].RenderWithModel(model);
    }
    
    public static string GetOrAddress(string lang, string key, object? model = null)
    {
        if (!Library.ContainsKey(lang) || !Library[lang].ContainsKey(key))
        {
            return $"{lang}:{key}";
        }

        return Library[lang][key].RenderWithModel(model);
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
        return DefaultLang;
    }
}