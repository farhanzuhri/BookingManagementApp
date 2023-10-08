namespace API.DTOs.Rooms
{
    public class RoomNotUsedTodayDto
    {
        public Guid RoomGuid { get; set; } 
        public string RoomName { get; set; } 
        public int Floor { get; set; } 
        public int Capacity { get; set; }
    }
}
