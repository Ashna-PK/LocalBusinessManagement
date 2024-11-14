using Booking.Api.Models;

namespace Booking.Api.Repository.IRepository
{
    public interface IBookingItemRepository
    {
        //public Task<BookingItem> createBookingItem(BookingItem bookingItem);
        public Task<BookingItem?> getBookingItemById(int id);
        public Task<List<BookingItem>> getBookingItemsByBookingId(int bookingId);
        public Task<List<BookingItem>> getBookingItemsByShopId(int shopId);
        //public Task<BookingItem> updateBookingItem(int id, BookingItem bookingItem);
        public Task<bool> deleteBookingItem(int id);
        public Task<List<BookingItem>> getBookingItemsByProductId(int productId);
        public Task<List<BookingItem>> getAllBookingItems();
    }
}
