using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Orchestration
{
    public class Auction
    {
        Business.Auction _auction = new Business.Auction();
        public Auction()
        {

        }
        public GenericResponse<AuctionContract> GetByID(AuctionContract auctionContract)
        {
            var returnObject = _auction.Select(auctionContract);
            return returnObject;
        }
        public GenericResponse<AuctionContract> InsertAuction(AuctionContract auctionContract)
        {
            var returnObject = _auction.Insert(auctionContract);
            return returnObject;
        }
        public GenericResponse<AuctionContract> UpdateAuction(AuctionContract auctionContract)
        {
            var returnObject = _auction.Update(auctionContract);
            return returnObject;
        }
        public GenericResponse<AuctionContract> DeleteAuction(AuctionContract auctionContract)
        {
            var returnObject = _auction.Delete(auctionContract);
            return returnObject;
        }
        public GenericResponse<List<AuctionContract>> SelectAuctionList()
        {
            var returnObject = _auction.SelectAuctionList();
            return returnObject;
        }
        public GenericResponse<AuctionContract> StartAuction(AuctionContract auctionContract, CarContract carContract)
        {
            GenericResponse<AuctionContract> returnObject = new GenericResponse<AuctionContract>();
            TimeSpan ts = new TimeSpan(10, 0, 0);
            auctionContract.CarID = carContract.ID;
            auctionContract.OwnerID = (int)carContract.OwnerID;
            auctionContract.StartDate = DateTime.Today.AddDays(1) + ts;
            returnObject = _auction.Insert(auctionContract);
            return returnObject;
        }
        public GenericResponse<List<AuctionContract>> AuctionListByOrder(string status)
        {
            GenericResponse<List<AuctionContract>> returnObject = new GenericResponse<List<AuctionContract>>();
            var response = SelectAuctionList();
            var auctionList = response.Value.Where<AuctionContract>(response => response.Status == status);
            returnObject.Value = auctionList.ToList();
            returnObject.Result = response.Result;
            returnObject.ResultMessage = response.ResultMessage;
            return returnObject;
        }

        
    }
}
