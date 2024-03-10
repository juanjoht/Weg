using System.Reflection;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WegGridApplication.Helpers;
using WegGridCore.Core;
using WegGridCore.Data;
using WegGridCore.EF;
using static System.Runtime.InteropServices.JavaScript.JSType;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Auto Mapper Configurations
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("localDB")));
builder.Services.AddScoped<IHeightRepository, HeightRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<CalculateGridLong>();
builder.Services.AddTransient<CalculateDifferenceLong>();
builder.Services.AddTransient<CalculateAmountGrid>();
builder.Services.AddTransient<ICalculateFactory, CalculateFactory>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Order}/{id?}");

app.Run();
