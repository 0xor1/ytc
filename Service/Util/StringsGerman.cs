namespace Dnsk.Service.Util;

public static partial class Strings
{
    private static readonly IReadOnlyDictionary<string, string> German = new Dictionary<string, string>()
    {
        { Invalid, "Ungültig" },
        { InvalidEmail, "Ungültige E-Mail" },
        { InvalidPwd, "Ungültiges Passwort" },
        { LessThan8Chars, "Weniger als 8 Zeichen" },
        { NoLowerCaseChar, "Kein Kleinbuchstabe" },
        { NoUpperCaseChar, "Kein Großbuchstabe" },
        { NoDigit, "Keine Ziffer" },
        { NoSpecialChar, "Kein Sonderzeichen" },
        { UnexpectedError, "Ein unerwarteter Fehler ist aufgetreten" },
        { AlreadyAuthenticated, "Bereits in authentifizierter Sitzung" },
        { NoMatchingRecord, "No matching record" },
    { InvalidEmailCode, "Invalid email code" },
    { InvalidResetPwdCode, "Invalid reset password code" },
    { AccountNotVerified, "account not verified, please check your emails for verification link" },
    { AuthAttemptRateLimit, "auth attempts cannot be made more frequently than every 5 seconds" }
    };
}