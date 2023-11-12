using Common.Shared;

namespace Dnsk.I18n;

public static partial class S
{
    private static readonly Dictionary<string, TemplatableString> English =
        new()
        {
            { HomeHeader, new("Hello, Dnsk!") },
            {
                HomeBody,
                new(
                    "<p>Welcome to your new dotnet starter kit.</p><p>You will find:</p><ul><li>Client: a blazor wasm app using radzen ui library</li><li>Server: aspnet with rpc pattern api and entity framework db interface</li></ul>"
                )
            },
            { Home, new("Home") },
            { Counter, new("Counter") },
            { MyCounter, new("My Counter") },
            { Increment, new("Increment") },
            { Decrement, new("Decrement") },
            { Incrementing, new("Incrementing") },
            { Decrementing, new("Decrementing") }
        };
}
