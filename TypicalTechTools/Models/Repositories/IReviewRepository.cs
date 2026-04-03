namespace TypicalTechTools.Models.Repositories
{
    public interface IReviewRepository
    {
        List<Review> GetReviews(int productCode);
        Review GetReviewById(int id);
        void AddReview(Review review);
        void EditReview(Review review);
        void DeleteReview(Review review);
    }
}
