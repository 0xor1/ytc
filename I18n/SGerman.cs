using Fluid;

namespace Dnsk.I18n;

public static partial class S
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
        { AuthConfirmEmailSubject, Parser.Parse("e-Mail-Adresse bestätigen")}, 
        { AuthConfirmEmailHtml, Parser.Parse("<div><a href=\"{{BaseHref}}/verify_email?email={{Email}}&code={{Code}}\">Bitte klicken Sie auf diesen Link, um Ihre E-Mail-Adresse zu bestätigen</a></div>")}, 
        { AuthConfirmEmailText, Parser.Parse("Bitte verwenden Sie diesen Link, um Ihre E-Mail-Adresse zu bestätigen: {{BaseHref}}/verify_email?email={{Email}}&code={{Code}}")},
        { AuthResetPwdSubject, Parser.Parse("Passwort zurücksetzen")}, 
        { AuthResetPwdHtml, Parser.Parse("<div><a href=\"{{BaseHref}}/reset_pwd?email={{Email}}&code={{Code}}\">klicken Sie bitte auf diesen Link, um Ihr Passwort zurückzusetzen</a></div>")}, 
        { AuthResetPwdText, Parser.Parse("Bitte klicken Sie auf diesen Link, um Ihr Passwort zurückzusetzen: {{BaseHref}}/reset_pwd?email={{Email}}&code={{Code}}")},
        { Home, Parser.Parse("Heim")},
        { L10n, Parser.Parse("Lokalisierung")},
        { Language, Parser.Parse("Sprache")},
        { DateFmt, Parser.Parse("Datumsformat")},
        { TimeFmt, Parser.Parse("Zeitformat")},
        { Register, Parser.Parse("Registrieren")},
        { SignIn, Parser.Parse("Anmelden")},
        { SignOut, Parser.Parse("Austragen")},
        { VerifyEmail, Parser.Parse("E-Mail bestätigen")},
        { ResetPwd, Parser.Parse("Passwort zurücksetzen")}
    };
}