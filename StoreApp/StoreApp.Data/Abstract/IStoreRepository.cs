using StoreApp.Data.Concrete;

namespace StoreApp.Data.Abstract;

public interface IStoreRepsository
{
    IQueryable<Product> Products { get; }  
    IQueryable<Category> Categories { get; }  

    void CreateProduct(Product entity);
}