using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Index(int page = 1)
    {
        var products = _storeRepsository
            .Products
            .Skip((page -1) * pageSize)//oteleme 
            .Select(p =>
            new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        }).Take(pageSize);

        return View(new ProductListViewModel
        {
            Products = products,
            PageInfo = new PageInfo
            {
                ItemsPerPage = pageSize,
                TotalItems = _storeRepsository.Products.Count(),
            }
        });
    }
    
}