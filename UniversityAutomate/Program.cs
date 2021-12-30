using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityAutomate;
using UniversityAutomate.Service;

var builder = WebApplication.CreateBuilder(args);

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AllowNullCollections = true;
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer("Server=LXIBY1093\\SQLEXPRESS;Database=UniversityDb;Trusted_Connection=True;"));
builder.Services.AddSingleton(mapper);

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

app.MapControllerRoute(
    name: "city",
    pattern: "{controller=Home}/{action=Index}/{cityName}");

app.MapControllerRoute(
    name: "group",
    pattern: "{controller=Home}/{action=Index}/{cityName}");

app.MapAreaControllerRoute(
    name: "adminCities",
    areaName: "Admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{cityId?}");

app.MapAreaControllerRoute(
    name: "adminUniversities",
    areaName: "Admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{universityId?}");

app.MapAreaControllerRoute(
    name: "adminGroups",
    areaName: "Admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{groupId?}");

app.MapAreaControllerRoute(
    name: "adminStudents",
    areaName: "Admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{studentId?}");


app.Run();
