using StoreApp.Data.Abstract;

namespace StoreApp.Data.Concrete;

public class EFStoreRepository : IStoreRepsository
{
    //context bagimlilik controller'dan buraya tasindi
    private StoreDbContext _context;  //StoreDbContext, DbContext'ten inheritance
    public EFStoreRepository(StoreDbContext context)
    {
        _context = context;
    }
    public IQueryable<Product> Products => _context.Products;
    public IQueryable<Category> Categories => _context.Categories;

    public void CreateProduct(Product entity)
    {
        throw new NotImplementedException();
    }
}