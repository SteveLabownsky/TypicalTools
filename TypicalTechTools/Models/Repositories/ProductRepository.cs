using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TypicalTechTools.Models.Data;

namespace TypicalTechTools.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TTDBContext _context;

        public ProductRepository(TTDBContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
             return _context.Products.Where(e => e.ProductCode == id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> SearchProducts(string search)
        {
            return _context.Products.Where(
                b => b.ProductName.ToUpper().Contains(search.ToUpper()) ||
                b.ProductDescription.ToUpper().Contains(search.ToUpper()))
                .ToList();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
