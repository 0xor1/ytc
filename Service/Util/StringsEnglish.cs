namespace Dnsk.Service.Util;

public static partial class Strings
{
    private static readonly IReadOnlyDictionary<string, string> English = new Dictionary<string, string>()
    {
        { Invalid, "Invalid" },
        { InvalidEmail, "Invalid email" },
        { InvalidPwd, "Invalid password" },
        { LessThan8Chars, "Less than 8 characters" },
        { NoLowerCaseChar, "No lowercase character" },
        { NoUpperCaseChar, "No uppercase character" },
        { NoDigit, "No digit" },
        { NoSpecialChar, "No special character" },
        { UnexpectedError, "An unexpected error occurred" },
        { AlreadyAuthenticated, "Already in authenticated session" },
        { NoMatchingRecord, "No matching record" },
        { InvalidEmailCode, "Invalid email code" },
        { InvalidResetPwdCode, "Invalid reset password code" },
        { AccountNotVerified, "account not verified, please check your emails for verification link" },
        { AuthAttemptRateLimit, "auth attempts cannot be made more frequently than every 5 seconds" }
    };
}