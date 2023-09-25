namespace API.Models
{
    public class Room : Date
    {
        public Guid Guid { get; set; }
        public int Floor {  get; set; }
        public int Capacity { get; set; }

    }
}
