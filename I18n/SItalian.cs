using Fluid;

namespace Dnsk.I18n;

public static partial class S
{
    private static readonly IReadOnlyDictionary<string, IFluidTemplate> Italian = new Dictionary<string, IFluidTemplate>()
    {
        { Invalid, Parser.Parse("Non valido") },
        { InvalidEmail, Parser.Parse("E-mail non valido") },
        { InvalidPwd, Parser.Parse("Password non valida") },
        { LessThan8Chars, Parser.Parse("Meno di 8 caratteri") },
        { NoLowerCaseChar, Parser.Parse("Nessun carattere minuscolo") },
        { NoUpperCaseChar, Parser.Parse("Nessun carattere maiuscolo") },
        { NoDigit, Parser.Parse("Nessuna cifra") },
        { NoSpecialChar, Parser.Parse("Nessun carattere speciale") },
        { UnexpectedError, Parser.Parse("Si è verificato un errore imprevisto") },
        { AlreadyAuthenticated, Parser.Parse("Già in sessione autenticata") },
        { NoMatchingRecord, Parser.Parse("Nessun record corrispondente") },
        { InvalidEmailCode, Parser.Parse("Codice e-mail non valido") },
        { InvalidResetPwdCode, Parser.Parse("Codice di reimpostazione della password non valido") },
        { AccountNotVerified, Parser.Parse("Account non verificato, controlla le tue e-mail per il link di verifica") },
        { AuthAttemptRateLimit, Parser.Parse("I tentativi di autenticazione non possono essere effettuati più frequentemente di ogni {{Seconds}} secondi") },
        { AuthConfirmEmailSubject, Parser.Parse("Conferma l'indirizzo e-mail")}, 
        { AuthConfirmEmailHtml, Parser.Parse("<div><a href=\"{{BaseHref}}/verify_email?email={{Email}}&code={{Code}}\">Fai clic su questo link per verificare il tuo indirizzo email</a></div>")}, 
        { AuthConfirmEmailText, Parser.Parse("Utilizza questo link per verificare il tuo indirizzo email: {{BaseHref}}/verify_email?email={{Email}}&code={{Code}}")},
        { AuthResetPwdSubject, Parser.Parse("Resetta la password")}, 
        { AuthResetPwdHtml, Parser.Parse("<div><a href=\"{{BaseHref}}/reset_pwd?email={{Email}}&code={{Code}}\">Fai clic su questo link per reimpostare la tua password</a></div>")}, 
        { AuthResetPwdText, Parser.Parse("Fai clic su questo link per reimpostare la tua password: {{BaseHref}}/reset_pwd?email={{Email}}&code={{Code}}")},
        { Home, Parser.Parse("Casa")},
        { L10n, Parser.Parse("Localizzazione")},
        { Language, Parser.Parse("Lingua")},
        { DateFmt, Parser.Parse("Formato data")},
        { TimeFmt, Parser.Parse("Formato orario")},
        { SignIn, Parser.Parse("Registrazione")},
        { SignOut, Parser.Parse("Disconnessione")}
    };
}