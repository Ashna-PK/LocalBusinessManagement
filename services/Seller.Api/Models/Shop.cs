using System.ComponentModel.DataAnnotations;

namespace Seller.Api.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        [Required]
        public string Description { get; set; }=string.Empty;
        [Required]
        public int SellerId { get; set; } //no need
        [Required]
        public bool isOpen { get; set; }
        public DateTime openTime { get; set; }
        public DateTime closeTime { get; set; }
        public decimal rating { get; set; }    //admin+user
    }
}
