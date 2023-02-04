using Fluid;

namespace Dnsk.I18n;

public static partial class S
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
        { AuthAttemptRateLimit, Parser.Parse("Les tentatives d'authentification ne peuvent pas être effectuées plus fréquemment que toutes les {{Seconds}} secondes") },
        { AuthConfirmEmailSubject, Parser.Parse("Confirmez votre adresse email")}, 
        { AuthConfirmEmailHtml, Parser.Parse("<div><a href=\"{{BaseHref}}/verify_email?email={{Email}}&code={{Code}}\">Veuillez cliquer sur ce lien pour vérifier votre adresse e-mail</a></div>")}, 
        { AuthConfirmEmailText, Parser.Parse("Veuillez utiliser ce lien pour vérifier votre adresse e-mail: {{BaseHref}}/verify_email?email={{Email}}&code={{Code}}")},
        { AuthResetPwdSubject, Parser.Parse("Réinitialiser le mot de passe")}, 
        { AuthResetPwdHtml, Parser.Parse("<div><a href=\"{{BaseHref}}/reset_pwd?email={{Email}}&code={{Code}}\">Veuillez cliquer sur ce lien pour réinitialiser votre mot de passe</a></div>")}, 
        { AuthResetPwdText, Parser.Parse("Veuillez cliquer sur ce lien pour réinitialiser votre mot de passe: {{BaseHref}}/reset_pwd?email={{Email}}&code={{Code}}")},
        { Home, Parser.Parse("Maison")},
        { L10n, Parser.Parse("Localisation")},
        { Language, Parser.Parse("Langue")},
        { DateFmt, Parser.Parse("Format de date")},
        { TimeFmt, Parser.Parse("Format de l'heure")},
        { Register, Parser.Parse("Enregistrer")},
        { SignIn, Parser.Parse("S'identifier")},
        { SignOut, Parser.Parse("Se déconnecter")},
        { VerifyEmail, Parser.Parse("Vérifier les courriels")},
        { ResetPwd, Parser.Parse("Réinitialiser le mot de passe")}
    };
}