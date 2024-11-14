using Booking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Api.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bookings> bookings { get; set; }
        public DbSet<BookingItem> bookingsItem { get; set; }
    }
}
