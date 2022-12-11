using Dnsk.Common;
using Dnsk.Proto;

namespace Dnsk.Client.Lib;

public enum ToastLevel
{
    Debug,
    Info,
    Warning,
    Error,
    Fatal
}
public record Toast(ToastLevel Level, string Message)
{
}
public interface IToaster
{
    void Show(Toast t);
}
public interface IToasterService : IToaster
{
    void Init(IToaster i);
}

public class ToasterService: IToasterService
{
    private IToaster? _impl;

    public void Init(IToaster i)
    {
        SelfService.Check(this, i);
        _impl ??= i;
    }

    public void Show(Toast t) => _impl?.Show(t);
}
