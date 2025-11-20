using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Web.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly); // /Models/MapperProfile.cs 

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:StoreDbConnection"],  b => b.MigrationsAssembly("StoreApp.Web")); // ikinci parametre, dbcontext'in .Data'da olmasina ragmen .Web'te calismasini dagladi
});

builder.Services.AddScoped<IStoreRepsository, EFStoreRepository>();//bu bir injection islemi-- Scoped, Transit, Singleton

var app = builder.Build();

app.UseStaticFiles();

// urun detay => samsung-s24
app.MapControllerRoute("product_details", "{name}", new {controller = "Home" , action = "Details" });

//kategori urun listesi => products/telefon 
app.MapControllerRoute("products_in_category", "products/{category?}", new {controller = "Home" , action = "Index" });

app.MapDefaultControllerRoute();

app.Run();
