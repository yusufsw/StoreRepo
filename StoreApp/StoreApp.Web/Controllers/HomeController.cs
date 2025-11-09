using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;

namespace StoreApp.Web.Controllers;

public class HomeController : Controller
{
    private IStoreRepsository _storeRepsository;
    public HomeController(IStoreRepsository storeRepository)
    {
        _storeRepsository = storeRepository;
    }
    public IActionResult Index() => View(); //arrow function
    
}