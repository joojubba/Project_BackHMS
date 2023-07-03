using System.Text.Json.Serialization;

namespace HotelManagementSystem.DataModels
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomType { get; set; }
        public bool RoomAvailable { get; set; }
        public string RoomDescription { get; set; }
        public RoomStatus Status { get; set; }

        [JsonIgnore]
        public virtual ICollection<Rate> Rates { get; set; } 
    }
    public enum RoomStatus
    {

        VacantClean,
        Blocked, 
        OccupiedClean,
        OccupiedDirty,      
        VacantDirty,
        NoShow,
        OutOrder,
        OutService,
    }
}
