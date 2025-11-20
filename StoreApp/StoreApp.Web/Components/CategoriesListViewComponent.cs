using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

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
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        return View(_storeRepsository.Categories.Select(c => new CategoryViewModel
        {
            Id = c.Id,
            Name = c.Name,
            Url = c.Url
        }).ToList());
    }
}