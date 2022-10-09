using Dnsk.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
// Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapGrpcService<CounterService>().EnableGrpcWeb();
app.MapFallbackToFile("index.html");

app.Run();
