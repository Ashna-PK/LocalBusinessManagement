using System.ComponentModel.DataAnnotations;

namespace Booking.Api.Models
{
    public class BookingItem
    {
        [Key]
        public int Id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }=string.Empty;
        public double price { get; set; }
        public int quantity { get; set; }
        public int  vendorId { get; set; }
    }
}
