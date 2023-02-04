using Dnsk.I18n;

namespace Dnsk.Client.Lib;

// L for Localizer
public static class L
{
    private static string _lang = Strings.DefaultLang;
    private static string _date = Strings.DefaultDateFmt;
    private static string _time = Strings.DefaultTimeFmt;
    
    public static void Config(string lang, string date, string time)
    {
        _lang = lang;
        _date = date;
        _time = time;
    }

    // S for String
    public static string S(string key, object? model = null) => Strings.GetOrAddress(_lang, key, model);

    // D for Date
    public static string D(DateTime dt) => dt.ToLocalTime().ToString(_date);

    // T for Time
    public static string T(DateTime dt) => dt.ToLocalTime().ToString(_time);
}