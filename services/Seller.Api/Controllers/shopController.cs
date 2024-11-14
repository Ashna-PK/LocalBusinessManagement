using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seller.Api.Data;
using Seller.Api.Models;
using Seller.Api.Repository.IRepository;

namespace Seller.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class shopController : ControllerBase
    {
        private readonly IShopRepository _context;

        public shopController(IShopRepository context)
        {
            _context = context;
        }

        // GET: api/SellerClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> Getshops()
        {
            var result = await _context.getShops();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // GET: api/SellerClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShop(int id)
        {
            var shop = await _context.getShopById(id);

            if (shop == null)
            {
                return NotFound();
            }

            return shop; ;
        }

        // PUT: api/SellerClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShop(int id, shopDto shop)
        {

            var result = await _context.editShop(id, shop);
            if (result == null)
            {
                return BadRequest();
            }

            //_context.Entry(userClass).State = EntityState.Modified;
            //return Ok();
            return Ok(result);
        }
        
        // POST: api/SellerClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shop>> PostShop(int sellerId,shopDto shop)
        {
            var result = await _context.addShopDetails(sellerId,shop);

            return Ok(result);
        }

        // DELETE: api/SellerClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var result = await _context.deleteShop(id);
            if (!result)/// result==null (dont do)
                return NotFound("seller not found.");
            return Ok(result);
        }
    }
}
