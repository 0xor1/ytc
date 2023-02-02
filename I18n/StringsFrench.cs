using Fluid;

namespace Dnsk.I18n;

public static partial class Strings
{
    private static readonly IReadOnlyDictionary<string, IFluidTemplate> French = new Dictionary<string, IFluidTemplate>()
    {
        { Invalid, Parser.Parse("Invalide") },
        { InvalidEmail, Parser.Parse("Email invalide") },
        { InvalidPwd, Parser.Parse("Mot de passe incorrect") },
        { LessThan8Chars, Parser.Parse("Moins de 8 caractères") },
        { NoLowerCaseChar, Parser.Parse("Pas de caractère minuscule") },
        { NoUpperCaseChar, Parser.Parse("Pas de caractère majuscule") },
        { NoDigit, Parser.Parse("Aucun chiffre") },
        { NoSpecialChar, Parser.Parse("Aucun caractère spécial") },
        { UnexpectedError, Parser.Parse("Une erreur inattendue est apparue") },
        { AlreadyAuthenticated, Parser.Parse("Déjà en session authentifiée") },
        { NoMatchingRecord, Parser.Parse("Aucun enregistrement correspondant") },
        { InvalidEmailCode, Parser.Parse("Code e-mail invalide") },
        { InvalidResetPwdCode, Parser.Parse("Code de mot de passe de réinitialisation invalide") },
        { AccountNotVerified, Parser.Parse("Compte non vérifié, veuillez vérifier vos e-mails pour le lien de vérification") },
        { AuthAttemptRateLimit, Parser.Parse("Les tentatives d'authentification ne peuvent pas être effectuées plus fréquemment que toutes les {{Seconds}} secondes") }
    };
}