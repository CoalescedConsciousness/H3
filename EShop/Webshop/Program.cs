using DAL;
using Serilog;
using Serilog.Events;
using ServiceLayer;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddDbContext<EfCoreContext>();
builder.Services.AddScoped<IProductService, ProductService>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMiniProfiler(options => options.RouteBasePath = "/profiler").AddEntityFramework();
builder.Services.AddSession();
builder.Services.AddRouting();
var app = builder.Build();
app.UseMiniProfiler();
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
app.UseSession();
app.UseAuthorization();

//app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

app.Run();
