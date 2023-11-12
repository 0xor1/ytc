using Common.Shared;

namespace Dnsk.I18n;

public static partial class S
{
    private static readonly Dictionary<string, TemplatableString> French =
        new()
        {
            { HomeHeader, new("Bonjour, Dnsk!") },
            {
                HomeBody,
                new(
                    "<p>Bienvenue dans votre nouveau kit de démarrage dotnet.</p><p>Vous trouverez:</p><ul><li>Client: une application blazor wasm utilisant bibliothèque radzen ui</li><li>Serveur: aspnet avec grpc api et interface de base de données du cadre d'entité</li></ul>"
                )
            },
            { Home, new("Maison") },
            { Counter, new("Comptoir") },
            { MyCounter, new("Mon Compteur") },
            { Increment, new("Incrément") },
            { Decrement, new("Décrémenter") },
            { Incrementing, new("Incrémentation") },
            { Decrementing, new("Décrémentation") }
        };
}
