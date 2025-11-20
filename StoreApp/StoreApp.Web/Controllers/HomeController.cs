using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;

public class HomeController : Controller
{
    public int pageSize = 3;
    private readonly IStoreRepsository _storeRepsository;
    private readonly IMapper _mapper;
    public HomeController(IStoreRepsository storeRepository, IMapper mapper)
    {
        _storeRepsository = storeRepository;
        _mapper = mapper;
    }
    public IActionResult Index(string category, int page = 1)
    {
        return View(new ProductListViewModel
        {
            Products = _storeRepsository.GetProductsByCategory(category,page,pageSize)
                        .Select(p => _mapper.Map<ProductViewModel>(p)),
            PageInfo = new PageInfo
            {
                ItemsPerPage = pageSize,
                CurrentPage = page,
                TotalItems = _storeRepsository.GetProductCount(category)
            }
        });
    }
    
}