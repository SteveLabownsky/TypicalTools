namespace TypicalTechTools.Models.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        List<Product> SearchProducts(String search);
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
    }
}
