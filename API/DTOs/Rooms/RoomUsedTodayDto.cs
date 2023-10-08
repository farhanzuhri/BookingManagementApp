namespace API.DTOs.Rooms
{
    public class RoomUsedTodayDto
    {
        public Guid BookingGuid { get; set; } 
        public string RoomName { get; set; }
        public string Status { get; set; } 
        public int Floor { get; set; } 
        public string BookBy { get; set; }
    }
}
