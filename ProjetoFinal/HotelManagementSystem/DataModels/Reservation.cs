using System.Text.Json.Serialization;

namespace HotelManagementSystem.DataModels
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public string Source { get; set; }
        public int Nights { get; set; }
        public int NumberGuests { get; set; }
        public decimal ReservationAmount { get; set; }
        public ReservationStatus ReservationStatus { get; set; }

        public virtual HotelGuest HotelGuest { get; set; }
        
        public virtual Rate Rate { get; set; }
        
        public virtual Room Room { get; set; }
    }

    public enum ReservationStatus
    {
        Reserved,
        Cancelled, 
        CheckedIn,
        CheckedOut,
        DueOut       
    }    
}
