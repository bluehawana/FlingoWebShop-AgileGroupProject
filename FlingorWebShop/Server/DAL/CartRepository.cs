using FlingorWebShop.Shared;
using Microsoft.EntityFrameworkCore;

namespace FlingorWebShop.Server.DAL
{
    public class CartRepository
    {
        private readonly WebsiteDbContext _websiteDbContext;

        public CartRepository(WebsiteDbContext websiteDbContext)
        {
            _websiteDbContext = websiteDbContext;
            _websiteDbContext.Database.EnsureCreated();
        }

        //Get all Carts?
        public async Task<List<CartDto>> GetAllActiveCartsAsync()
        {
            var dbCarts = await _websiteDbContext.CartDetails.Where(c => c.Amount > 0).ToListAsync();
            var newCarts = new List<CartDto>();
            
            foreach (var cartDetail in dbCarts)
            {
                //Om newCarts innehåller användaren.
                if (newCarts.Any(c => c.UserId == cartDetail.UserId))
                {
                    var existingUser = newCarts.Find(c => c.UserId == cartDetail.UserId);
                    
                    // Lägg till produkten på den användaren
                    if (existingUser.Products.Any(p => p.ProductId == cartDetail.ProductId))
                        existingUser.Products.Find(p => p.ProductId == cartDetail.ProductId).Amount += 1;
                    else
                        existingUser.Products
                            .Add(new ProductDto() { ProductId = cartDetail.ProductId, Amount = cartDetail.Amount });
                    continue;
                }

                // annars

                // Skapa användaren
                var user = new CartDto() { UserId = cartDetail.UserId, Products = new List<ProductDto>() };

                // Lägg sedan till produkten
                if (user.Products.Any(p => p.ProductId == cartDetail.ProductId))
                    user.Products.Find(p => p.ProductId == cartDetail.ProductId).Amount += 1;
                else
                    user.Products
                        .Add(new ProductDto(){ProductId = cartDetail.ProductId, Amount = cartDetail.Amount});

                // Lägg till användaren i listan
                newCarts.Add(user);
            }

            return newCarts;
        }

        //Get one cart.
        public async Task<List<ProductDto>> GetCartAsync(int userId)
        {
            var cart = new List<ProductDto>();

            foreach (var cartDetail in _websiteDbContext.CartDetails.Where(c => c.UserId == userId))
            {
                cart.Add(new ProductDto()
                {
                    //TODO: Change to ArticleNumber?
                    ProductId = cartDetail.ProductId,
                    Amount = cartDetail.Amount
                });
            }
            return cart;
        }

        public async Task<bool> SaveCartAsnyc(List<ProductDto> cart, int userId)
        {
            if (userId <= 0) return false;

                var existingCart = await _websiteDbContext.CartDetails
                .Where(cd => cd.UserId == userId).ToListAsync();

            foreach (var cartDetail in existingCart)
            {
                _websiteDbContext.CartDetails.Remove(cartDetail);
            }

            foreach (var product in cart)
            {
                var detail = new CartDetail()
                {
                    UserId = userId,
                    ProductId = product.ProductId,
                    Amount = product.Amount
                };

                _websiteDbContext.CartDetails.Add(detail);
            }

            await _websiteDbContext.SaveChangesAsync();
            return true;
        }
    }
}
