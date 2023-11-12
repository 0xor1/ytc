using Common.Shared;

namespace Dnsk.I18n;

public static partial class S
{
    private static readonly Dictionary<string, TemplatableString> Italian =
        new()
        {
            { HomeHeader, new("Ciao, Dnsk!") },
            {
                HomeBody,
                new(
                    "<p>Benvenuto nel tuo nuovo starter kit dotnet.</p><p>Troverai:</p><ul><li>Client: un'app blazor wasm che utilizza Libreria radzen ui</li><li>Server: aspnet con interfaccia grpc api e entità framework db</li></ul>"
                )
            },
            { Home, new("Casa") },
            { Counter, new("Contatore") },
            { MyCounter, new("Il mio contatore") },
            { Increment, new("Incremento") },
            { Decrement, new("Decremento") },
            { Incrementing, new("Incremento") },
            { Decrementing, new("Diminuzione") }
        };
}
