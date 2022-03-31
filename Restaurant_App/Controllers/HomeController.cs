using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Restaurant_App.Data;
using Restaurant_App.Models;
using Restaurant_App.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Restaurant_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustomerRepository _customerRepo;
        private readonly ItemRepository _itemRepo;
        private readonly PaymentTypeRepository _paymentTypeRepo;

        public HomeController(ILogger<HomeController> logger, RestaurantContext context)
        {
            
            _logger = logger;
            _customerRepo = new CustomerRepository(context);
            _itemRepo = new ItemRepository(context);
            _paymentTypeRepo = new PaymentTypeRepository(context);
        }

        public async Task<IActionResult> Index()
        {
            var ContainerObject = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(await _customerRepo.GetAll(), 
                await _itemRepo.GetAll(),
                await _paymentTypeRepo.GetAll());

            return View(ContainerObject);
        }

        [HttpGet]
        [Route("Home/GetItemUnitPrice/{itemId:int}")]
        public IActionResult GetItemUnitPrice(int itemId)
        {
            var theItem_Uprice =  _itemRepo.GetItem(itemId);
            var Uprice = theItem_Uprice.Price;
            return Json(new { Price = Uprice });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
