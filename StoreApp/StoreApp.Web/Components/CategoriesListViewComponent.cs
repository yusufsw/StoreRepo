using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;

namespace StoreApp.Web.Components;

public class CategoriesListViewComponent: ViewComponent
{
    private readonly IStoreRepsository _storeRepsository; 
    public CategoriesListViewComponent(IStoreRepsository storeRepsository)
    {
        _storeRepsository = storeRepsository;
    }
    public IViewComponentResult Invoke()
    {
        return View(_storeRepsository
        .Products
        .Select(c=> c.Category)
        .Distinct()
        .OrderBy(c => c));
    }
}