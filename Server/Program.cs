using Dnsk.Shared.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
app.MapGrpcService<CounterService>();
app.MapFallbackToFile("index.html");
app.Run();
