namespace HotelManagementSystem.DataModels
{
    public class Rate
    {
        public int RateId { get; set; }
        public string RateCode { get; set; }
        public decimal RatePrice { get; set; }
        public string RateDescription { get; set; }

        public virtual Room Room { get; set; }
    }
}

