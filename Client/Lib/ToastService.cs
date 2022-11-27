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
    Task Show(Toast t);
}
public interface IToasterService : IToaster
{
    void Init(IToaster t);
}

public class ToasterService: IToasterService
{
    private IToaster? _toaster;

    public void Init(IToaster t)
    {
        _toaster = t;
    }
    public async Task Show(Toast t)
    {
        await (_toaster?.Show(t) ?? Task.CompletedTask);
    }
}
