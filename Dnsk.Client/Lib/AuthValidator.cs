using System.Text.RegularExpressions;
using Common.Shared;
using Radzen;

namespace Dnsk.Client.Lib;

public static class AuthValidator
{
    public static ValidationResult EmailValidator(IRadzenFormComponent component) =>
        Common.Shared.AuthValidator.Email(component.GetValue() as string ?? "");

    public static ValidationResult PwdValidator(IRadzenFormComponent component) =>
        Common.Shared.AuthValidator.Pwd(component.GetValue() as string ?? "");
}
