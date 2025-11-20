using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;

public class HomeController : Controller
{
    public int pageSize = 3;
    private IStoreRepsository _storeRepsository;
    public HomeController(IStoreRepsository storeRepository)
    {
        _storeRepsository = storeRepository;
    }
    public IActionResult Index(string category, int page = 1)
    {
        return View(new ProductListViewModel
        {
            Products = _storeRepsository.GetProductsByCategory(category,page,pageSize).Select(p =>
                    new ProductViewModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Description = p.Description,
                            Price = p.Price
                        }),
            PageInfo = new PageInfo
            {
                ItemsPerPage = pageSize,
                CurrentPage = page,
                TotalItems = _storeRepsository.GetProductCount(category)
            }
        });
    }
    
}