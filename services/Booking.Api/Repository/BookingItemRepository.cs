using Booking.Api.Data;
using Booking.Api.Migrations;
using Booking.Api.Models;
using Booking.Api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Booking.Api.Repository
{
    public class BookingItemRepository : IBookingItemRepository
    {
        public BookingDbContext _context;
        public BookingItemRepository(BookingDbContext context)
        {
            _context = context;
        }
        //public async Task<BookingItem> createBookingItem(BookingItem bookingItem)
        //{
        //    _context.bookingsItem.Add(bookingItem);
        //    await _context.SaveChangesAsync();

        //    return bookingItem;
        //}

        public async Task<bool> deleteBookingItem(int id)
        {
            var item = await _context.bookingsItem.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _context.bookingsItem.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<BookingItem>> getAllBookingItems()
        {
            
            return await _context.bookingsItem.ToListAsync();
        }

        public async Task<BookingItem?> getBookingItemById(int id)
        {
            var item = await _context.bookingsItem.FindAsync(id);

            if (item == null)
            {
                return new BookingItem();
            }

            return item;
        }

        public async Task<List<BookingItem>> getBookingItemsByBookingId(int bookingId)
        {
            var item = await _context.bookingsItem.Where(x => x.orderId == bookingId).ToListAsync();
            if (item == null)
            {
                return new List<BookingItem>();
            }

            return item;
        }

        public async Task<List<BookingItem>> getBookingItemsByProductId(int productId)
        {
            var item = await _context.bookingsItem.Where(x => x.productId == productId).ToListAsync();
            if (item == null)
            {
                return new List<BookingItem>();
            }

            return item;
        }

        public async Task<List<BookingItem>> getBookingItemsByShopId(int shopId)
        {
            var item = await _context.bookingsItem.Where(x => x.vendorId == shopId).ToListAsync();
            if (item == null)
            {
                return new List<BookingItem>();
            }

            return item;
        }

        //public async Task<BookingItem> updateBookingItem(int id, BookingItem bookingItem)
        //{
        //    var item = await _context.bookingsItem.FindAsync(id);
        //    //_context.Entry(seller).State = EntityState.Modified;
        //    if (item == null)
        //    { return new BookingItem(); }
        //    item.quantity = bookingItem.quantity;
        //    item.price = bookingItem.price;
        //    item.productName = bookingItem.productName;


        //    var result = _context.bookingsItem.Any(e => e.Id == id);

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!result)
        //        {
        //            return new BookingItem();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return item;
        //}
    }
   
}