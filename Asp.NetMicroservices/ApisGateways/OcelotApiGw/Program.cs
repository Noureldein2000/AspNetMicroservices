using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
;

var builder = WebApplication.CreateBuilder(args);

 //✅ إضافة ملفات إعدادات Ocelot
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true);
});

// Ocelot Basic setup
//builder.Configuration
//    .SetBasePath(builder.Environment.ContentRootPath)
//    .AddOcelot(); // single ocelot.json file in read-only mode
//builder.Services
//    .AddOcelot(builder.Configuration);

// ✅ إضافة تسجيل الدخول (Logging)
builder.Logging.ClearProviders(); // اختياري لمسح الإعدادات الافتراضية إن رغبت
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddOcelot(builder.Configuration)
      .AddCacheManager(x => x.WithDictionaryHandle());

var app = builder.Build();

app.MapGet("/", () => "Hello World from Downstream!");

await app.UseOcelot();

app.Run();
