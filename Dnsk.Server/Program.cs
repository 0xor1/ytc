using Dnsk.Service.Services;
using Common.Server;
using Dnsk.Db;
using Dnsk.I18n;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiServices<DnskDb>(S.UnexpectedError);

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
app.MapGrpcService<ApiService>();
app.MapFallbackToFile("index.html");
app.Run(Config.Server.Listen);
