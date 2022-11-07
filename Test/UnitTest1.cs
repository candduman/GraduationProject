using Base;
using Orchestration;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Types;
using System.Linq;
using NUnit.Framework.Constraints;

namespace Test
{
    public class Tests
    {
        public Car car = new Car();
        public Auction auction = new Auction();
        [SetUp]
        public void Setup() { }
        [Test]
        public void TestCar()
        {
            var response = car.GetCarList();
        }
        [Test]
        public void InsertAuction()
        {
            AuctionContract auctionContract = new AuctionContract();
            var response = auction.InsertAuction(auctionContract);
        }
        [Test]
        public void StartAuction()
        {
            for (int i = 0; i < 10; i++)
            {
                AuctionContract auctionContract = new AuctionContract();
                CarContract carContract = new CarContract();
                carContract.ID = 2;
                carContract.OwnerID = 3;
                auctionContract.Status = "OnGoing";
                carContract.Status = auctionContract.Status;
                auctionContract.StartPrice = 100000;
                var response = auction.StartAuction(auctionContract, carContract);
            }
        }
        [Test]
        public void ListInAuctionCars()
        {
            var response = auction.AuctionListByOrder("OnGoing");
            var response2 = auction.AuctionListByOrder("Sold");
            var response3 = auction.AuctionListByOrder("Waiting");
        }

        [Test]
        public void CarAuctionMatching()
        {
            var response = auction.AuctionListByOrder("OnGoing");
            foreach (AuctionContract auction in response.Value)
            {
                CarContract carContract = new CarContract();
                carContract.ID = auction.CarID;
                car.GetCar(carContract);
            }
        }
        [Test]
        public void asdas()
        {
            TransactionManager transactionManager = new TransactionManager();
            CarContract carContract = new CarContract();
            transactionManager.Get(carContract);
        }
    }
}