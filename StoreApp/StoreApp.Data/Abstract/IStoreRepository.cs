using StoreApp.Data.Concrete;

namespace StoreApp.Data.Abstract;

public interface IStoreRepsository
{
    IQueryable<Product> Products { get; }

    void CreateProduct(Product entity);
}