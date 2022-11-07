using Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    [Serializable]
    public class CarContract:IContract
    {
        public CarContract() { }

        #region Public members
        public int? ID { get; set; }
        public string? Brand { get; set; }
        public string? Series { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public string? Fuel { get; set; }
        public string? Gear { get; set; }
        public string? Status { get; set; }
        public string? BodyType { get; set; }
        public long? Kilometer { get; set; }
        public int? EnginePower { get; set; }
        public string? EngineCapacity { get; set; }
        public string? Color { get; set; }
        public string? Warranty { get; set; }
        public string? VehicleStatus { get; set; }
        public int? OwnerID { get; set; }

        #endregion

        public AuctionContract auctionContract { get; set; }
    }
}
