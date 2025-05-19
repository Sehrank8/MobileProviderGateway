using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text.Json;
using System.Text.RegularExpressions;


static void ConfigureOcelotJson()
{
    var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "ocelot.template.json");
    var finalPath = Path.Combine(Directory.GetCurrentDirectory(), "ocelot.json");

    var json = File.ReadAllText(templatePath);

    json = json.Replace("__DOWNSTREAM_API_HOST__", Environment.GetEnvironmentVariable("DOWNSTREAM_API_HOST") ?? "localhost");
    json = json.Replace("__GATEWAY_HOST__", Environment.GetEnvironmentVariable("GATEWAY_HOST") ?? "localhost");

    File.WriteAllText(finalPath, json);
}


var builder = WebApplication.CreateBuilder(args);

ConfigureOcelotJson();
builder.Configuration.AddJsonFile("ocelot.json");



builder.Services.AddOcelot().AddConfigPlaceholders();

var app = builder.Build();


await app.UseOcelot();

app.Run();
