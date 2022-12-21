
using Humanizer;

namespace Dnsk.Common;

public static class EnumExts
{
    public static string CssClass(this Enum input)
        => input.Humanize(LetterCasing.LowerCase).Replace(" ", "");
}