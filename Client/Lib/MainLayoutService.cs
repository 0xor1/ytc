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

public enum Theme
{
    Light,
    Dark,
    // ColorBlind
}
public interface IMainLayout
{
    void Left(bool? show = null);
    void PopToast(Toast t);
    void SetTheme(Theme t);
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
    public void PopToast(Toast t) => _impl?.PopToast(t);
    public void SetTheme(Theme t) => _impl?.SetTheme(t);

}