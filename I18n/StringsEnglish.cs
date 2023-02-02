using Fluid;

namespace Dnsk.I18n;

public static partial class Strings
{
    private static readonly IReadOnlyDictionary<string, IFluidTemplate> English = new Dictionary<string, IFluidTemplate>()
    {
        { Invalid, Parser.Parse("Invalid") },
        { InvalidEmail, Parser.Parse("Invalid email") },
        { InvalidPwd, Parser.Parse("Invalid password") },
        { LessThan8Chars, Parser.Parse("Less than 8 characters") },
        { NoLowerCaseChar, Parser.Parse("No lowercase character") },
        { NoUpperCaseChar, Parser.Parse("No uppercase character") },
        { NoDigit, Parser.Parse("No digit") },
        { NoSpecialChar, Parser.Parse("No special character") },
        { UnexpectedError, Parser.Parse("An unexpected error occurred") },
        { AlreadyAuthenticated, Parser.Parse("Already in authenticated session") },
        { NoMatchingRecord, Parser.Parse("No matching record") },
        { InvalidEmailCode, Parser.Parse("Invalid email code") },
        { InvalidResetPwdCode, Parser.Parse("Invalid reset password code") },
        { AccountNotVerified, Parser.Parse("Account not verified, please check your emails for verification link") },
        { AuthAttemptRateLimit, Parser.Parse("Authentication attempts cannot be made more frequently than every {{Seconds}} seconds") }
    };
}