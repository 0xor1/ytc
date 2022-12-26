using System.Text.RegularExpressions;
using Radzen;

namespace Dnsk.Client.Lib;

public static class AuthValidator
{
    public static (bool Valid, List<string> SubRules) EmailValidator(IRadzenFormComponent component)
    {
        var res = (Valid: true, SubRules: new List<string>());
        var str = component.GetValue() as string ?? "";
        if (!Regex.IsMatch(str, @"^[^@]+@[^@]+\.[^@]+$"))
        {
            res.Valid = false;
        }
        return res;
    }

    public static (bool Valid, List<string> SubRules) PwdValidator(IRadzenFormComponent component)
    {
        var res = (Valid: true, SubRules: new List<string>());
        var str = component.GetValue() as string ?? "";
        if (!Regex.IsMatch(str, ".{8,}"))
        {
            res.Valid = false;
            res.SubRules.Add("less than 8 characters");
        }
        if (!Regex.IsMatch(str, "[a-z]"))
        {
            res.Valid = false;
            res.SubRules.Add("no lowercase character");
        }
        if (!Regex.IsMatch(str, "[A-Z]"))
        {
            res.Valid = false;
            res.SubRules.Add("no uppercase character");
        }
        if (!Regex.IsMatch(str, "[0-9]"))
        {
            res.Valid = false;
            res.SubRules.Add("no digit");
        }
        if (!Regex.IsMatch(str, "[^a-zA-Z0-9 ]"))
        {
            res.Valid = false;
            res.SubRules.Add("no special character");
        }
        return res;
    }
}