namespace Ytc.Client.Test;

public class CounterPageTests : TestBase
{
    [Fact]
    public async Task PageWrapper_Success()
    {
        var ali = await NewTestPack("ali");
        ali.Ctx.RenderComponent<Ytc.Client.Pages.CounterPage>();
        ali.Ctx.DisposeComponents();
    }
}
