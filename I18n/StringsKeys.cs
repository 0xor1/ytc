using Common;

namespace Dnsk.I18n;

public static partial class Strings
{
    public const string Invalid = AuthValidator.Strings.Invalid;
    public const string InvalidEmail = AuthValidator.Strings.InvalidEmail;
    public const string InvalidPwd = AuthValidator.Strings.InvalidPwd;
    public const string LessThan8Chars = AuthValidator.Strings.LessThan8Chars;
    public const string NoLowerCaseChar = AuthValidator.Strings.NoLowerCaseChar;
    public const string NoUpperCaseChar = AuthValidator.Strings.NoUpperCaseChar;
    public const string NoDigit = AuthValidator.Strings.NoDigit;
    public const string NoSpecialChar = AuthValidator.Strings.NoSpecialChar;
    public const string UnexpectedError = "unexpected_error";
    public const string AlreadyAuthenticated = "already_authenticated";
    public const string NoMatchingRecord = "no_matching_record";
    public const string InvalidEmailCode = "invalid_email_code";
    public const string InvalidResetPwdCode = "invalid_reset_pwd_code";
    public const string AccountNotVerified = "account_not_verified";
    public const string AuthAttemptRateLimit = "auth_attempt_rate_limit";
}