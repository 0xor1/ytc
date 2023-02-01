namespace Dnsk.Service.Util;

public static partial class Strings
{
    private static readonly IReadOnlyDictionary<string, string> Italian = new Dictionary<string, string>()
    {
        { Invalid, "Non valido" },
        { InvalidEmail, "E-mail non valido" },
        { InvalidPwd, "Password non valida" },
        { LessThan8Chars, "Meno di 8 caratteri" },
        { NoLowerCaseChar, "Nessun carattere minuscolo" },
        { NoUpperCaseChar, "Nessun carattere maiuscolo" },
        { NoDigit, "Nessuna cifra" },
        { NoSpecialChar, "Nessun carattere speciale" },
        { UnexpectedError, "Si è verificato un errore imprevisto" },
        { AlreadyAuthenticated, "Già in sessione autenticata" },
        { NoMatchingRecord, "No matching record" },
        { InvalidEmailCode, "Invalid email code" },
        { InvalidResetPwdCode, "Invalid reset password code" },
        { AccountNotVerified, "account not verified, please check your emails for verification link" },
        { AuthAttemptRateLimit, "auth attempts cannot be made more frequently than every 5 seconds" }
    };
}