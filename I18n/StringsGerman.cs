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
        { AuthAttemptRateLimit, Parser.Parse("Authentifizierungsversuche können nicht häufiger als alle {{Seconds}} Sekunden durchgeführt werden") },
        { AuthConfirmEmailSubject, Parser.Parse("Confirm Email Address")}, 
        { AuthConfirmEmailHtml, Parser.Parse("<div><a href=\"{{BaseHref}}/verify_email?email={{Email}}&code={{Code}}\">please click this link to verify your email address</a></div>")}, 
        { AuthConfirmEmailText, Parser.Parse("please use this link to verify your email address: {{BaseHref}}/verify_email?email={{Email}}&code={{Code}}")},
        { AuthResetPwdSubject, Parser.Parse("Reset Password")}, 
        { AuthResetPwdHtml, Parser.Parse("<div><a href=\"{{BaseHref}}/reset_pwd?email={{Email}}&code={{Code}}\">please click this link to reset your password</a></div>")}, 
        { AuthResetPwdText, Parser.Parse("please click this link to reset your password: {{BaseHref}}/reset_pwd?email={{Email}}&code={{Code}}")}
    };
}