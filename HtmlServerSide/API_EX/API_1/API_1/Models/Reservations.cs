namespace sharp_01.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string? Client { get; set; }
        public int Room { get; set; }
        public int Nights { get; set; }
    }
}
