using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BD_First.Data;
using BD_First.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Spark.Sql;

var builder = WebApplication.CreateBuilder(args);
var baseAddress = "https://localhost:7292/";

#region Builder
// Add DB and Services
builder.Services.AddDbContext<BD_FirstContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BD_FirstContext") ?? throw new InvalidOperationException("Connection string 'BD_FirstContext' not found.")));

builder.Services.AddScoped<WeatherService>();

// Enable use of Endpoints for WebAPI calls
builder.Services.AddMvc(options => options.EnableEndpointRouting = false)
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

// Add clients used for outgoing API calls
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
// Add support for Routing used for API call functionality.
app.UseRouting();
app.UseMvcWithDefaultRoute();

app.Run();
#endregion