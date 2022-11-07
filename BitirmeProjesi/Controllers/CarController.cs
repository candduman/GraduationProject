using Microsoft.AspNetCore.Mvc;

namespace ZBitirmeProjesi.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
            }
        [HttpPost]
        public async Task<IActionResult> GetSingleCar()
        {



            return View();
        }
    }
}
