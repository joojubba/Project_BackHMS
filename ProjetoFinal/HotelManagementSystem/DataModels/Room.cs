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

        public virtual ICollection<Rate> Rates { get; set; }

    }
    public enum RoomStatus
    {

        Blocked, 
        OccupiedClean,
        OccupiedDirty,
        VacantClean,
        VacantDirty,
        NoShow,
        OutOrder,
        OutService,
    }
}
