namespace HotelManagementSystem.DataModels
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
