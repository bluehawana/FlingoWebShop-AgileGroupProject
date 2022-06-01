using FlingorWebShop.Shared;
using Microsoft.EntityFrameworkCore;

namespace FlingorWebShop.Server.DAL
{
    public class ProductRepository
    {
        private readonly WebsiteDbContext _websiteDbContext;

        public ProductRepository(WebsiteDbContext websiteDbContext)
        {
            _websiteDbContext = websiteDbContext;
            //TODO This is not needed after real database has been created.
            _websiteDbContext.Database.EnsureCreated();
        }

        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            return await _websiteDbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _websiteDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<bool> CreateProduct(Product? product)
        {
            if (product is null) return false;

            if (await GetProductAsync(product.Id) is not null) return false;

            await _websiteDbContext.Products.AddAsync(product);
            await _websiteDbContext.SaveChangesAsync();
            return true;
        }
    }
}
