using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class Bookin
    {
        [Key]
        public int BookinId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingStatus { get; set; } = "pending";
    }
}
