using Common.Shared;

namespace Dnsk.I18n;

public static partial class S
{
    private static readonly Dictionary<string, TemplatableString> German =
        new()
        {
            { HomeHeader, new("Hallo, Dnsk!") },
            {
                HomeBody,
                new(
                    "<p>Willkommen bei Ihrem neuen dotnet-Starterkit.</p><p>Sie finden:</p><ul><li>Client: eine Blazor-Wasm-App, die verwendet radzen ui library</li><li>Server: aspnet mit grpc api und Entity Framework db interface</li></ul>"
                )
            },
            { Home, new("Heim") },
            { Counter, new("Schalter") },
            { MyCounter, new("Mein Zähler") },
            { Increment, new("Zuwachs") },
            { Decrement, new("Dekrementieren") },
            { Incrementing, new("Inkrementieren") },
            { Decrementing, new("Dekrementieren") }
        };
}
