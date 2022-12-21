using Dnsk.Common;

namespace Dnsk.Client.Lib;

public enum ToastLevel
{
    Debug,
    Info,
    Warning,
    Error,
    Fatal
}

public record Toast(ToastLevel Level, string Message);

public interface IMainLayout
{
    void PopToast(Toast t);
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

    public void PopToast(Toast t) => _impl?.PopToast(t);

}