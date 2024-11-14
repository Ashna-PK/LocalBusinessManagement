using Booking.Api.Data;
using Booking.Api.Migrations;
using Booking.Api.Models;
using Booking.Api.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Booking.Api.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingDbContext _context;
        //public BookingItemRepository _item;
        public BookingRepository(BookingDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Bookings> createOrder(Bookings booking)
        {
            //if (booking.orderDate == null)
            //{
            //    booking.orderDate = DateTime.Now;
            //}

            // Save the Order first to generate the orderId
            //_context.Add(booking);
            //Console.WriteLine("Order created with ID: " + book);

            double TAmount = 0.0;
            //HashSet<string> vendorIds = new HashSet<string>();
            List<BookingItem> items=[];
            // Fetch product details, check stock, and update order items
            foreach (var item in booking.orderItems)
            {
                var client = _httpClientFactory.CreateClient();
                var getApiURL = $"https://localhost:7162/api/Product/{item.productId}";
                var response = await client.GetAsync(getApiURL);
                var result=await response.Content.ReadAsStringAsync();
                //var product = await _context.products.getProductById(item.productId);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    // Deserialize JSON response into Product object
                    var product = JsonSerializer.Deserialize<Product>(jsonString); // or JsonConvert.DeserializeObject<Product>(jsonString);
                    if (product != null)
                    {
                        Console.WriteLine("Fetched product details for product ID: " + product.Id);
                        int stockQuantity = product.quantity;                 
                        double price = (double)product.Price;
                        string productName = product.Name;
                        int vendorId = product.shopId;
                        if (stockQuantity < item.quantity)
                        {
                            throw new InvalidOperationException("Insufficient stock for product: " + productName);
                        }
                        TAmount += price * item.quantity;
                        // Set product details to the order item
                        var bookedItem = new BookingItem
                        {
                            productId = product.Id,
                            orderId= item.orderId,
                            productName = product.Name,
                            price = (double)product.Price,
                            quantity = product.quantity,
                            vendorId = product.shopId // Assuming vendorId is mapped from shopId
                        };
                        // Save the order item
                        items.Add(bookedItem);
                        content con = new content
                        {
                            productid = item.productId,
                            quantity = item.quantity
                        };
                        var putApiUrl = $"https://localhost:7162/api/Product/{product.Id}/quantity";
                        var jsonContent = JsonSerializer.Serialize(con); // Or JsonConvert.SerializeObject for Newtonsoft.Json

                        // Wrap the JSON string in StringContent, setting the content type to application/json
                        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        var putResponse = await client.PutAsync(putApiUrl, httpContent);
                    }
                    else
                    {
                        Console.WriteLine("Failed to deserialize product information.");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to fetch product details. Status Code: {response.StatusCode}");
                }
                
            }
            Bookings Book = new Bookings()
            {
                Userid = booking.Userid,
                orderDate = DateTime.Now,
                totalAmount = TAmount,
                orderItems = items,
            };
            _context.Add(Book);
            await _context.SaveChangesAsync();
            return Book;
        }

        public async Task<bool> deleteOrder(int id)
        {
            var item = await _context.bookings.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _context.bookings.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<Bookings>> getOrders()
        {
            return await _context.bookings.ToListAsync();
        }
        public async Task<Bookings?> getOrderById(int id)
        {
            var item = await _context.bookings.FindAsync(id);

            if (item == null)
            {
                return new Bookings();
            }

            return item;
        }

        public async Task<List<Bookings>> getOrdersByUserId(int userId)
        {
            var item = await _context.bookings.Where(x => x.Userid == userId).ToListAsync();
            if (item == null)
            {
                return new List<Bookings>();
            }

            return item;
        }

        //public Task<Bookings> updateOrder(int id, Bookings booking)
        //{
        //    throw new NotImplementedException();
        //}
    }
     public class content
    {
        public int productid { get; set; }
        public int quantity { get; set; }
    }
}
