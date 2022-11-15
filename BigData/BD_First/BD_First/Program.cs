using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BD_First.Data;
using BD_First.Service;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var baseAddress = "https://localhost:7292/";

#region Builder
builder.Services.AddDbContext<BD_FirstContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BD_FirstContext") ?? throw new InvalidOperationException("Connection string 'BD_FirstContext' not found.")));
builder.Services.AddScoped<WeatherService>();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false)
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

builder.Services.AddHttpClient();
builder.Services.AddHttpClient("localapi", client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddHttpClient("DMI", client =>
{
    client.BaseAddress = new Uri("https://dmigw.govcloud.dk");
});
builder.Services.AddScoped<HttpClient>(sp => {
    IHttpClientFactory factory = sp.GetRequiredService<IHttpClientFactory>();
    return factory.CreateClient("localapi");
});
#endregion
#region App

var app = builder.Build();

// ApiKey = "ceeaa353-a263-4f66-b29d-9a14a3724a38";
// curl - X GET "https://dmigw.govcloud.dk/v2/climateData" - H "X-Gravitee-Api-Key: ceeaa353-a263-4f66-b29d-9a14a3724a38"
// Municipality (Sorø): 0340
// Ex: https://dmigw.govcloud.dk/v2/climateData/collections/municipalityValue/items?municipalityId=0340&api-key=ceeaa353-a263-4f66-b29d-9a14a3724a38

//app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.UseMvcWithDefaultRoute();

app.Run();
#endregion