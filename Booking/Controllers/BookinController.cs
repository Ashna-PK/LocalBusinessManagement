using Booking.Models;
using Booking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookinController : ControllerBase
    {
        private readonly IBookinServices _bookinServices;
        public BookinController(IBookinServices bookinServices)
        {
            _bookinServices = bookinServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookin>>> GetDetails()
        {

            return Ok(await _bookinServices.GetAllBooks());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             var details=await _bookinServices.ViewBookingDetails(id);
              
                if (details != null)
                {
                    return Ok(details);
                }
                return NoContent();
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(BookinDto bookin, int prodid, int custid, Decimal price)
        {
           
              var result= await  _bookinServices.CreateBooking(bookin,prodid,custid,price);
                if(result)
                return Ok();
                return BadRequest();
            
        }
        [HttpPut]
        public async Task<IActionResult> Upadating(int id, BookinDto bookin)
        {
            
              var result= await  _bookinServices.UpdateBooking(id,bookin);
                if(result)
                return Ok();
                return BadRequest();
            
        }
        [HttpDelete]
        public async Task<IActionResult> Cancelling(int id)
        {
           
                bool result= await _bookinServices.DeleteBooking(id);
                if(result)
                {
                    return Ok();
                }
                return NotFound();
            
        }

        
    }
}
