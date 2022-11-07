using Base;


namespace Types
{
    public class AuctionContract
    {
        public int AuctionID { get; set; }  
        public int? CarID { get; set; }  
        public long? AdvertNumber { get; set; }
        public long StartPrice { get; set; }
        public long? EndPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OwnerID { get; set; }
        public int? LastOwnerID { get; set; }
        public string? Status { get; set; }
    }
}
