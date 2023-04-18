using Common.Shared.Auth;
using Dnsk.Api.Counter;

namespace Dnsk.Api;

public interface IApi : Common.Shared.Auth.IApi
{
    private static IApi? _inst;
    public static IApi Init() => _inst ??= new Api();

    public ICounterApi Counter { get; }
}

internal class Api: IApi
{
    public IAuthApi Auth { get; } = IAuthApi.Init();
    public ICounterApi Counter { get; } = ICounterApi.Init();
}