using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Webshop.Data;
using Webshop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webshop.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Blazored.LocalStorage;
using Webshop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddDbContext<WebshopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebshopContext") ?? throw new InvalidOperationException("Connection string 'WebshopContext' not found.")));
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false)
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
var baseAddress = "https://localhost:7290/";
builder.Services.AddScoped(sp =>
{
    var client = new HttpClient();
    client.BaseAddress = new Uri(baseAddress);
    return client;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseMvcWithDefaultRoute();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();
