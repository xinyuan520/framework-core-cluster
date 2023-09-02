//var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


using Discus.Shared.WebApi.Extensions;

var webApiAssembly = System.Reflection.Assembly.GetExecutingAssembly();
var serviceInfo = ServiceInfo.CreateInstance(webApiAssembly);
var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureDefault(serviceInfo).Build();

app.UseCustomMiddleware();

await app.ChangeThreadPoolSettings().UseConsul(serviceInfo.Id).RunAsync();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
