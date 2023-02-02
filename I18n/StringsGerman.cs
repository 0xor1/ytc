using Fluid;

namespace Dnsk.I18n;

public static partial class Strings
{
    private static readonly IReadOnlyDictionary<string, IFluidTemplate> German = new Dictionary<string, IFluidTemplate>()
    {
        { Invalid, Parser.Parse("Ungültig") },
        { InvalidEmail, Parser.Parse("Ungültige E-Mail") },
        { InvalidPwd, Parser.Parse("Ungültiges Passwort") },
        { LessThan8Chars, Parser.Parse("Weniger als 8 Zeichen") },
        { NoLowerCaseChar, Parser.Parse("Kein Kleinbuchstabe") },
        { NoUpperCaseChar, Parser.Parse("Kein Großbuchstabe") },
        { NoDigit, Parser.Parse("Keine Ziffer") },
        { NoSpecialChar, Parser.Parse("Kein Sonderzeichen") },
        { UnexpectedError, Parser.Parse("Ein unerwarteter Fehler ist aufgetreten") },
        { AlreadyAuthenticated, Parser.Parse("Bereits in authentifizierter Sitzung") },
        { NoMatchingRecord, Parser.Parse("Kein übereinstimmender Datensatz") },
        { InvalidEmailCode, Parser.Parse("Ungültiger E-Mail-Code") },
        { InvalidResetPwdCode, Parser.Parse("Ungültiger Passwort-Reset-Code") },
        { AccountNotVerified, Parser.Parse("Konto nicht bestätigt, bitte überprüfen Sie Ihre E-Mails auf den Bestätigungslink") },
        { AuthAttemptRateLimit, Parser.Parse("Authentifizierungsversuche können nicht häufiger als alle {{Seconds}} Sekunden durchgeführt werden") }
    };
}