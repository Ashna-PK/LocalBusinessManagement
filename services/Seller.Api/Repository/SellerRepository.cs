using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Seller.Api.Data;
using Seller.Api.Models;

namespace Seller.Api.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly SellerDbContext _context;
        public SellerRepository(SellerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SellerClass>> getSellers()
        {
            return await _context.sellers.ToListAsync();

        }

        public async Task<SellerClass> getSellerById(int id)
        {
            var seller = await _context.sellers.FindAsync(id);

            if (seller == null)
            {
                return new SellerClass();
            }

            return seller;
        }
        public async Task<SellerClass> createSeller(SellerDto sellerDto)
        {
            SellerClass seller = new SellerClass()
            {
                Name = sellerDto.Name,
                Address = sellerDto.Address,
                Email = sellerDto.Email,
                PhoneNumber = sellerDto.PhoneNumber,
                City = sellerDto.City,
                PostalCode = sellerDto.PostalCode,
                BusinessLicense = sellerDto.BusinessLicense,

            };
            await _context.sellers.AddAsync(seller);
            await _context.SaveChangesAsync();

            return seller;

        }

        public async Task<bool> deleteSeller(int id)
        {
            var seller = await _context.sellers.FindAsync(id);
            if (seller == null)
            {
                return false;
            }

            _context.sellers.Remove(seller);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<SellerClass> editProfile(int id, SellerDto seller)
        {
            var sellerEdit = await _context.sellers.FindAsync(id);
            //_context.Entry(seller).State = EntityState.Modified;
            if (sellerEdit == null)
            { return new SellerClass(); }

            sellerEdit.Address = seller.Address;
            sellerEdit.Email = seller.Email;
            sellerEdit.Name = seller.Name;
            sellerEdit.PhoneNumber = seller.PhoneNumber;
            sellerEdit.City = seller.City;
            sellerEdit.PostalCode = seller.PostalCode;
            sellerEdit.BusinessLicense = seller.BusinessLicense;
            var result = _context.sellers.Any(e => e.Id == id);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!result)
                {
                    return new SellerClass();
                }
                else
                {
                    throw;
                }
            }
            return sellerEdit;
        }
        //public async Task<bool> StatusUpdate(int id,string status)
        //{
        //    var seller = await _context.sellers.FindAsync(id);
        //    if (seller == null)
        //        return false;
        //    seller.status = status;
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
        public async Task<bool> adminVerify(int id, bool isVerified, decimal rating)
        {
            var seller = await _context.sellers.FindAsync(id);
            var shop=await _context.shops.FirstOrDefaultAsync(x=>x.SellerId==id);
            if (seller == null)
                return false;
            if (shop == null)
                return false;
            seller.IsVerified = isVerified;
            shop.rating = rating;
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}
