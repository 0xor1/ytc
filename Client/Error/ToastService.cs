using Dnsk.Proto;

namespace Dnsk.Client.Error;
public record Toast(ToastLevel Level, string Message);
public interface IToaster
{
    void Show(Toast t);
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
    public void Show(Toast t)
    {
        _toaster?.Show(t);
    }
}
