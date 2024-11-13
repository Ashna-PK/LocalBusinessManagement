using AutoMapper;
using Booking.Data;
using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Services
{
    public class BookinServices : IBookinServices
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public BookinServices( IMapper mapper ,AppDbContext appDbContext) {
            _mapper = mapper;
        _appDbContext = appDbContext;
        }
        public async Task<bool> StatusUpdate(int id, string status)
        {
            var seller = await _appDbContext.Bookings.FindAsync(id);
            if (seller == null)
            {
                return false;
            }
            seller.BookingStatus= status;
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        public  async Task<bool> CreateBooking(BookinDto details,int prodid,int custid,Decimal price)
        {
            var bookingEntity = _mapper.Map<Bookin>(details);
            bookingEntity.ProductId = prodid;
            bookingEntity.CustomerId = custid;
            bookingEntity.TotalPrice = price;
            bookingEntity.BookingStatus = "Reserving Product";
            bookingEntity.BookingDate = DateTime.Now;
            _appDbContext.Bookings.Add(bookingEntity);

            await _appDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Bookin>> GetAllBooks()
        {
            return await _appDbContext.Bookings.ToListAsync();
        }
        public async Task<Bookin> ViewBookingDetails(int BookingId)
        { 
            return await _appDbContext.Bookings.FindAsync(BookingId);
            
          }
        public async Task< bool>UpdateBooking(int BookingId, BookinDto bookin)
        {
            var details=await _appDbContext.Bookings.FindAsync(BookingId);
            if (details == null) return false;
            details.Adress = bookin.Adress;
            details.PhoneNo = bookin.PhoneNo;
            details.Quantity = bookin.Quantity;
            _appDbContext.Bookings.Update(details);
            await _appDbContext.SaveChangesAsync();
            return true;

        }
        public  async Task< bool> DeleteBooking(int BookingId)
        {
            var details =  await _appDbContext.Bookings.FindAsync(BookingId);
            if (details == null) return false;
            _appDbContext.Bookings.Remove (details);
            _appDbContext.SaveChangesAsync();
           
            return true;
        }

           
    }
}
