using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BD_First.Data;
using BD_First.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Spark.Sql;
using Microsoft.Spark;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Sql.Types;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

#region Fetch Configured Settings:
var baseAddress = builder.Configuration.GetSection("URIs")["local"];
var targetAddress = builder.Configuration.GetSection("URIs")["target"];
var sqLiteStore = builder.Configuration.GetSection("FileStores")["sqlite"];
#endregion

#region Configure SQLite
var cString = builder.Configuration.GetConnectionString("WeatherData") ?? "Data Source=WeatherData.db";
// !! Remember to transfer db file to Container:
//> docker cp "C:\Users\Santiak\Desktop\EUC\h3\BigData\BD_First\BD_First\WeatherData.db" 2603ad0bab34f611714a2cf774429034eddd12a6dd741429b20fe91c70dd694b:data.db"
#endregion
#region Configure Spark
// Configure Spark
// -- Nearly working; connection times out between Spark and Metabase, maybe firewall?
SparkSession spark = SparkSession.Builder()
                                .AppName("weather")
                                .GetOrCreate();

DataFrame df = spark.Read().Json(@"c:\bin\data.json");
#endregion
#region Builder
// Add DB and Services
//builder.Services.AddDbContext<BD_FirstContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("BD_FirstContext") ?? throw new InvalidOperationException("Connection string 'BD_FirstContext' not found.")));
builder.Services.AddSqlite<BD_FirstContext>(cString);
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
    client.BaseAddress = new Uri(targetAddress);
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