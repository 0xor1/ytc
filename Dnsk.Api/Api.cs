using Common.Shared;
using Common.Shared.Auth;
using Dnsk.Api.Counter;

namespace Dnsk.Api;

public interface IApi : Common.Shared.Auth.IApi
{
    public ICounterApi Counter { get; }
}

public class Api : IApi
{
    public Api(IRpcClient client)
    {
        Auth = new AuthApi(client);
        Counter = new CounterApi(client);
    }

    public IAuthApi Auth { get; }
    public ICounterApi Counter { get; }
}
