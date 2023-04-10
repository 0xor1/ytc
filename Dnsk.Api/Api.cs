using Common.Shared.Auth;

namespace Dnsk.Api;

public interface IApi : Common.Shared.Auth.IApi
{
    private static IApi? _inst;
    public static IApi Init() => _inst ??= new Api();
}

internal class Api: IApi
{
    public IAuthApi Auth { get; } = IAuthApi.Init();
}