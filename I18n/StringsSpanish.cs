using Fluid;

namespace Dnsk.I18n;

public static partial class Strings
{
    private static readonly IReadOnlyDictionary<string, IFluidTemplate> Spanish = new Dictionary<string, IFluidTemplate>()
    {
        { Invalid, Parser.Parse("Inválido") },
        { InvalidEmail, Parser.Parse("Email inválido") },
        { InvalidPwd, Parser.Parse("Contraseña invalida") },
        { LessThan8Chars, Parser.Parse("Menos de 8 caracteres") },
        { NoLowerCaseChar, Parser.Parse("Sin carácter en minúsculas") },
        { NoUpperCaseChar, Parser.Parse("Sin carácter en mayúscula") },
        { NoDigit, Parser.Parse("Sin dígito") },
        { NoSpecialChar, Parser.Parse("Sin carácter especial") },
        { UnexpectedError, Parser.Parse("Ocurrió un error inesperado") },
        { AlreadyAuthenticated, Parser.Parse("Ya en sesión autenticada") },
        { NoMatchingRecord, Parser.Parse("Sin registro coincidente") },
        { InvalidEmailCode, Parser.Parse("Código de correo electrónico no válido") },
        { InvalidResetPwdCode, Parser.Parse("Código de restablecimiento de contraseña no válido") },
        { AccountNotVerified, Parser.Parse("Cuenta no verificada, revise sus correos electrónicos para ver el enlace de verificación") },
        { AuthAttemptRateLimit, Parser.Parse("Los intentos de autenticación no se pueden realizar con más frecuencia que cada {{Seconds}} segundos") }
    };
}