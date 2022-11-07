using Orchestration;
using Microsoft.AspNetCore.Mvc;
using Types;
using Base;

namespace BitirmeProjesi.Controllers
{
    public class AuctionsController : Controller
    {

        public Car car = new Car();
        public Auction auction = new Auction();
        public async Task<IActionResult> Index()
        {

            var liveauctions = auction.AuctionListByOrder("OnGoing");
            GenericResponse<List<CarContract>> returnobject = new GenericResponse<List<CarContract>>();
            returnobject.Value = new List<CarContract>();
            foreach (var liveauction in liveauctions.Value)
            {
                CarContract contract = new CarContract();
                contract.ID = liveauction.CarID;
                var response = car.GetCar(contract);
                if (response.Value is not null)
                {
                    response.Value.auctionContract = liveauction;
                    returnobject.Value.Add(response.Value);
                }
            }
            return View(returnobject);
        }
        public IActionResult CarSingle()
        {
            return View();
        }

    }
}
