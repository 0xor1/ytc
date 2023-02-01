namespace Dnsk.Service.Util;

public static partial class Strings
{
    private static readonly IReadOnlyDictionary<string, string> French = new Dictionary<string, string>()
    {
        { Invalid, "Invalide" },
        { InvalidEmail, "Email invalide" },
        { InvalidPwd, "Mot de passe incorrect" },
        { LessThan8Chars, "Moins de 8 caractères" },
        { NoLowerCaseChar, "Pas de caractère minuscule" },
        { NoUpperCaseChar, "Pas de caractère majuscule" },
        { NoDigit, "Aucun chiffre" },
        { NoSpecialChar, "Aucun caractère spécial" },
        { UnexpectedError, "Une erreur inattendue est apparue" },
        { AlreadyAuthenticated, "Déjà en session authentifiée" },
        { NoMatchingRecord, "No matching record" },
        { InvalidEmailCode, "Invalid email code" },
        { InvalidResetPwdCode, "Invalid reset password code" },
        { AccountNotVerified, "account not verified, please check your emails for verification link" },
        { AuthAttemptRateLimit, "auth attempts cannot be made more frequently than every 5 seconds" }
    };
}