using Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Types;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        Orchestration.Auction auction = new Orchestration.Auction();
        Orchestration.Car car = new Orchestration.Car();
        [HttpGet]
        public JsonResult GetByID(AuctionContract auctionContract)
        {
            var response = auction.GetByID(auctionContract);
            return new JsonResult(response);
        }
        [HttpPost]
        public JsonResult Insert(AuctionContract auctionContract)
        {
            auctionContract.StartDate = DateTime.Now;
            auctionContract.EndDate = DateTime.Now.AddDays(1);
            var response = auction.InsertAuction(auctionContract);
            return new JsonResult(response);
        }
        //[Route("SelectAuctionList2")]
        //[HttpGet]
        //public JsonResult SelectAuctionList()
        //{
        //    var response = auction.SelectAuctionList();
        //    return new JsonResult(response);
        //}
        [HttpPut]
        public JsonResult UpdateAuction(AuctionContract auctionContract)
        {
            var response = auction.UpdateAuction(auctionContract);
            return new JsonResult(response);
        }
        [HttpDelete]
        public JsonResult DeleteAuction(AuctionContract auctionContract)
        {
            var response = auction.DeleteAuction(auctionContract);
            return new JsonResult(response);
        }
        [Route("SelectAuctionList")]
        [HttpGet]
        public JsonResult SelectLiveAuctionList()
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
    }
}
