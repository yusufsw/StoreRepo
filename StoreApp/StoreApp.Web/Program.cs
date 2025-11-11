using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:StoreDbConnection"],  b => b.MigrationsAssembly("StoreApp.Web")); // ikinci parametre dbcontext .Data'da olmasina ragmen .Web'te calismasini dagladi
});

builder.Services.AddScoped<IStoreRepsository, EFStoreRepository>();//bu bir injection islemi-- Scoped, Transit, Singleton

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
