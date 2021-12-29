using Microsoft.EntityFrameworkCore;
using UniversityAutomate;
using UniversityAutomate.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

builder.Services.AddMvc();


var app = builder.Build();
app.Configuration.Bind("Project", new Config());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "cities",
    areaName: "Admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{cityId?}");

app.MapAreaControllerRoute(
    name: "universities",
    areaName: "Admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{universityId?}");

app.MapAreaControllerRoute(
    name: "groups",
    areaName: "Admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{groupId?}");


app.Run();
