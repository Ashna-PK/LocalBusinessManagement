using Seller.Api.Models;

namespace Seller.Api.Repository.IRepository
{
    public interface IReviewRepository
    {
        public Task<IEnumerable<Review>> getReviewByShop(string shopName);
        public Task<Review> getReviewById(int id);
        public Task<bool> postReview(Review review);

    }
}
