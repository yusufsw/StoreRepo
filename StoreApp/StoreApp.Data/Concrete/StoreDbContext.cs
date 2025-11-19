using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    //for seed database 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // junction table definition for add extra features
        modelBuilder.Entity<Product>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Products)
            .UsingEntity<ProductCategory>();

        // unique Url at category
        modelBuilder.Entity<Category>()
            .HasIndex(u => u.Url)
            .IsUnique();

        modelBuilder.Entity<Product>().HasData(
            new List<Product>()
            {
                new() { Id=1, Name="Samsung S24", Price=50000, Description="Guzel telefon"},
                new() { Id=2, Name="Samsung S25", Price=60000, Description="Guzel telefon"},
                new() { Id=3, Name="Samsung S26", Price=70000, Description="Guzel telefon"},
                new() { Id=4, Name="Samsung S27", Price=80000, Description="Guzel telefon"},
                new() { Id=5, Name="Samsung S28", Price=90000, Description="Guzel telefon"},
                new() { Id=6, Name="Samsung S28", Price=90000, Description="Guzel telefon"},
                //new() { Id=7, Name="Arcelik Camasir Makinesi", Price=100000, Description="Guzel makine"},
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new List<Category>()
            {
                new() { Id=1, Name="Telefon", Url="telefon"},
                new() { Id=2, Name="Beyaz Esya", Url="beyaz-esya"}, // extension method yada slug dotnet kutuphanesi oto url tanimlamasi 
                new() { Id=3, Name="Elektronik", Url="elektronik"}
            }
        );

        //junction table -> kesisim tablosu
        modelBuilder.Entity<ProductCategory>().HasData(
            new List<ProductCategory>()
            {
                new ProductCategory() {ProductId=1 , CategoryId=1},      
                new ProductCategory() {ProductId=1 , CategoryId=2},       
                new ProductCategory() {ProductId=2 , CategoryId=1},      
                new ProductCategory() {ProductId=3 , CategoryId=1},      
                new ProductCategory() {ProductId=4 , CategoryId=1},      
                new ProductCategory() {ProductId=5 , CategoryId=3},      
                new ProductCategory() {ProductId=6 , CategoryId=3},      
               // new ProductCategory() {ProductId=7 , CategoryId=2},      
            }
        );

    }
}