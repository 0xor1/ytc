using Common.Shared;

namespace Dnsk.I18n;

public static partial class S
{
    private static readonly Dictionary<string, TemplatableString> Spanish =
        new()
        {
            { HomeHeader, new("¡Hola, Dnsk!") },
            {
                HomeBody,
                new(
                    "<p>Bienvenido a su nuevo kit de inicio de dotnet.</p><p>Encontrará:</p><ul><li>Cliente: una aplicación blazor wasm usando biblioteca radzen ui</li><li>Servidor: aspnet con grpc api e interfaz db del marco de la entidad</li></ul>"
                )
            },
            { Home, new("Hogar") },
            { Counter, new("Contador") },
            { MyCounter, new("Mi Contador") },
            { Increment, new("Incremento") },
            { Decrement, new("Decremento") },
            { Incrementing, new("Incrementando") },
            { Decrementing, new("Decreciente") }
        };
}
