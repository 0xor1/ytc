using Dnsk.Common;

namespace Dnsk.Client.Lib;

public interface IMainLayout
{
    void Left(bool? show = null);
}
public interface IMainLayoutService : IMainLayout
{
    void Init(IMainLayout i);
}

public class MainLayoutService: IMainLayoutService
{
    private IMainLayout? _impl;

    public void Init(IMainLayout i)
    {
        SelfService.Check(this, i);
        _impl ??= i;
    }

    public void Left(bool? show = null) => _impl?.Left(show);

}