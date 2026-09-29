namespace CRM.domain
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = "";
        public string RoomType { get; set; } = "";
        public string Status { get; set; } = "Available";
        public decimal Price { get; set; }
    }
}