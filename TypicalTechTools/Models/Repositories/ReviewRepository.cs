using Microsoft.EntityFrameworkCore;
using TypicalTechTools.Models.Data;

namespace TypicalTechTools.Models.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly TTDBContext _context;
        
        public ReviewRepository(TTDBContext context)
        { 
            _context = context;
        }

        public void AddReview(Review review)
        {
            throw new NotImplementedException();
        }

        public void DeleteReview(Review review)
        {
            throw new NotImplementedException();
        }

        public void EditReview(Review review)
        {
            throw new NotImplementedException();
        }

        public Review GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviews(int productCode)
        {
            return _context.Reviews.Include(p => p.Product).Where(r => r.ProductCode == productCode).ToList();
        }
    }
}
