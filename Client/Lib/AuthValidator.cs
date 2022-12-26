using System.Text.RegularExpressions;
using Dnsk.Common;
using Radzen;

namespace Dnsk.Client.Lib;

public static class AuthValidator
{
    public static ValidationResult EmailValidator(IRadzenFormComponent component)
        => Common.AuthValidator.Email(component.GetValue() as string ?? "");

    public static ValidationResult PwdValidator(IRadzenFormComponent component)
        => Common.AuthValidator.Pwd(component.GetValue() as string ?? "");
}