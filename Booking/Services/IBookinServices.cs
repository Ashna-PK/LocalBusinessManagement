using Booking.Models;

namespace Booking.Services
{
    public interface IBookinServices
    {
        public Task<bool> CreateBooking(BookinDto bookin, int prodid, int custid, Decimal price);
        public Task<IEnumerable<Bookin>> GetAllBooks();
        public Task<Bookin> ViewBookingDetails(int BookingId);
        public Task<bool> UpdateBooking(int BookingId,BookinDto bookin);
        public Task<bool> DeleteBooking(int BookingId);
    }
}
