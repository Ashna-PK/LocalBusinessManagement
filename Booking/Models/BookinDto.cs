using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class BookinDto
    {
        [Required]
        public string Adress { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
