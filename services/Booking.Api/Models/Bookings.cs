namespace Booking.Api.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public DateTime orderDate { get; set; }
        public double totalAmount {  get; set; }
        public List<BookingItem> orderItems {  get; set; }=new List<BookingItem>();
        //public List<int> vendorIds { get; set; } =new List<int>();

    }
}
