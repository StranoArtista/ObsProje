using ObsProje.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextService();
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

app.UseAuthorization();
//Ogrenci Area Route
app.MapAreaControllerRoute(
    name: "Ogrenci",
    areaName: "Ogrenci",
    pattern: "Ogrenci/{controller=Ogrenci}/{action=Index}/{id?}");
//Ogretmen Area Route
app.MapAreaControllerRoute(
    name: "Ogretmen",
    areaName: "Ogretmen",
    pattern: "Ogretmen/{controller=Ogretmen}/{action=Index}/{id?}");
//Idare Area Route
app.MapAreaControllerRoute(
    name: "Idare",
    areaName: "Idare",
    pattern: "Idare/{controller=Admin}/{action=Index}/{id?}");
//Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
