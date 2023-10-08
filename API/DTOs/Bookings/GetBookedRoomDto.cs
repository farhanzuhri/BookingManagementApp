namespace API.DTOs.Bookings
{
    public class GetBookedRoomDto
    {
        public Guid BookingGuid { get; set; }
        public string RoomName { get; set; }
        public string Status { get; set; }
        public int Floor { get; set; }
        public string BookedBy { get; set; }
    }
}
