using Seller.Api.Data;
using Seller.Api.Models;

namespace Seller.Api.Repository.IRepository
{
    public interface IShopRepository
    {
        public Task<IEnumerable<Shop>> getShops();
        public Task<Shop> addShopDetails(int sellerId, shopDto shop);
        public Task<bool> deleteShop(int id);
        public Task<Shop> editShop(int id, shopDto shop);
        public Task<Shop> getShopById(int SellerId);
    }
}
