using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ✅ إضافة ملفات إعدادات Ocelot
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true);
});

// ✅ إضافة تسجيل الدخول (Logging)
builder.Logging.ClearProviders(); // اختياري لمسح الإعدادات الافتراضية إن رغبت
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddOcelot();

var app = builder.Build();

app.MapGet("/hello", () => "Hello World from Downstream!");

await app.UseOcelot();

app.Run("http://localhost:5010");
