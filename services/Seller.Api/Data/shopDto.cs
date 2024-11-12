using System.ComponentModel.DataAnnotations;

namespace Seller.Api.Data
{
    public class shopDto
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }= string.Empty;  
        public bool isOpen { get; set; }
        public DateTime openTime { get; set; }
        public DateTime closeTime { get; set; }
        
    }
}
