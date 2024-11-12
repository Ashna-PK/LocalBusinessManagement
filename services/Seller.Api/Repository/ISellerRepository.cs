using Seller.Api.Data;
using Seller.Api.Models;

namespace Seller.Api.Repository
{
    public interface ISellerRepository
    {
        public  Task<IEnumerable<SellerClass>> getSellers();
        public Task<SellerClass> getSellerById(int id);
        public Task<SellerClass> createSeller(SellerDto sellerDto);
        public Task<bool> deleteSeller(int id);
        public Task<SellerClass> editProfile(int id, SellerDto seller);
        public Task<bool> adminVerify(int id,bool isVerified,decimal rating);
    }
}
