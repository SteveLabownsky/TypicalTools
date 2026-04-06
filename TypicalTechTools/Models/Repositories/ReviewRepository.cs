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
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void DeleteReview(Review review)
        {
            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }

        public void EditReview(Review review)
        {
            _context.Reviews.Update(review);
            _context.SaveChanges();
        }

        public Review GetReviewById(int id)
        {
            return _context.Reviews.Where(r => r.ReviewId == id).FirstOrDefault();
        }

        public List<Review> GetReviews(int productCode)
        {
            return _context.Reviews.Include(p => p.Product).Where(r => r.ProductCode == productCode).ToList();
        }
    }
}
