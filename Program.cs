global using EmployeeTimeMonitor.Data;
global using EmployeeTimeMonitor.Models;
global using EmployeeTimeMonitor.Enums;
using EmployeeTimeMonitor.Interfaces;
using EmployeeTimeMonitor.Repository;
using EmployeeTimeMonitor.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registering the dependencies
builder.Services.AddScoped<IEmployeeTimerRepository, EmployeeTimerRepository>();
builder.Services.AddScoped<IEmployeeTimerService, EmployeeTimerService>();

builder.Services.AddSession();


builder.Services.AddDbContextPool<EmployeeTimerDBContext>(option =>
                        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
