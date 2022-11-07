using Base;
using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orchestration;
using Types;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        Orchestration.Auction auction = new Orchestration.Auction();
        Orchestration.Car car = new Orchestration.Car();
        public CarController()
        {

        }
        [HttpPost]
        public JsonResult Insert(CarContract car)
        {
            Orchestration.Car _car = new Orchestration.Car();
            var response = _car.InsertCar(car);
            return new JsonResult(response);
        }
        [HttpGet]
        public JsonResult Get(CarContract car)
        {
            Orchestration.Car _car = new Orchestration.Car();
            var response = _car.GetCar(car);
            return new JsonResult(response);
        }
        [HttpDelete]

        public JsonResult DeleteCar(CarContract car) 
        {
            Orchestration.Car _car = new Orchestration.Car();
            var response = _car.DeleteCar(car);
            return new JsonResult(response);
        }
        [Route("GetCarList")]
        [HttpGet]
        public JsonResult GetCarList()
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
            return new JsonResult(returnobject);
        }
        [HttpPut]
        public JsonResult UpdateCar(CarContract carContract)
        {
            Orchestration.Car _car = new Orchestration.Car();
            var response = _car.UpdateCar(carContract);
            return new JsonResult(response);
        }
    }
}
