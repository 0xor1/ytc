using Common.Shared;

namespace Ytc.I18n;

public static partial class S
{
    public static readonly Common.Shared.S Inst;

    static S()
    {
        Inst = Strings.FromCommon(Library);
    }
}
