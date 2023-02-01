namespace Dnsk.Service.Util;

public static partial class Strings
{
    private static readonly IReadOnlyDictionary<string, string> Spanish = new Dictionary<string, string>()
    {
        { Invalid, "Inválido" },
        { InvalidEmail, "Email inválido" },
        { InvalidPwd, "Contraseña invalida" },
        { LessThan8Chars, "Menos de 8 caracteres" },
        { NoLowerCaseChar, "Sin carácter en minúsculas" },
        { NoUpperCaseChar, "Sin carácter en mayúscula" },
        { NoDigit, "Sin dígito" },
        { NoSpecialChar, "Sin carácter especial" },
        { UnexpectedError, "Ocurrió un error inesperado" },
        { AlreadyAuthenticated, "Ya en sesión autenticada" },
        { NoMatchingRecord, "No matching record" },
        { InvalidEmailCode, "Invalid email code" },
        { InvalidResetPwdCode, "Invalid reset password code" },
        { AccountNotVerified, "account not verified, please check your emails for verification link" },
        { AuthAttemptRateLimit, "auth attempts cannot be made more frequently than every 5 seconds" }
    };
}