
using System.Text.Json.Serialization;

namespace HotelManagementSystem.DataModels
{
    public class HotelGuest
    {
        public int HotelGuestId { get; set; }
        public string HotelGuestName { get; set; }
        public string HotelGuestIdentification { get; set; }
        public string HotelGuestEmail { get; set; }
        public int HotelGuestPhone { get; set; }
        public string HotelGuestAddress { get; set; }
        public DateTime DateBirthHotelGuest { get; set; }

        [JsonIgnore]
        public virtual ICollection<Reservation> reservations { get; set; }
    }
}
