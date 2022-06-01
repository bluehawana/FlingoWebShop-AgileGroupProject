using System.Net.Http.Json;
using FlingorWebShop.Shared;

namespace FlingorWebShop.Client.DAL
{
    public class CartManager
    {
        private readonly HttpClient _httpClient;
        private Cart _cart;
        private int? _userId;

        // Event to signal that the cart content has changed in some way.
        // Should be invoked whenever the cart has changed.
        public event EventHandler CartContentUpdated;

        public CartManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _cart = new Cart();
        }

        public void SetUserId(int id)
        {
            _userId = id;
        }

        public void ResetUserId()
        {
            _userId = null;
        }

        public async Task GetCartAsync()
        {
            if (_userId is null)
            {
                _cart = new Cart();
                CartContentUpdated.Invoke(this, new EventArgs { });
                return;
            }

            var cart = await _httpClient.GetFromJsonAsync<List<ProductDto>>($"api/Cart/{_userId}");
            if (cart is null)
            {
                _cart = new Cart();
                return;
            }

            var newCart = new Cart()
            {
                Products = new Dictionary<Product, int>(),
                UserId = _userId,
                TotalPrice = 0
            };

            foreach (var productDto in cart)
            {
                //TODO: This can be optimized better
                var product = await _httpClient.GetFromJsonAsync<Product>($"api/Product/{productDto.ProductId}");
                if (product is null) continue;
                newCart.AddProduct(product, productDto.Amount);
            }

            _cart = newCart;
            CartContentUpdated.Invoke(this, new EventArgs { });
        }

        public async Task AddToCart(Product product, int quantity = 1)
        {
            _cart.AddProduct(product, quantity);
            await SaveCartAsync();
            await GetCartAsync();
            CartContentUpdated.Invoke(this, new EventArgs { });
        }

        public async Task RemoveFromCart(int productId, int quantity = 1)
        {
            _cart.DeleteProduct(productId, quantity);
            await SaveCartAsync();
            await GetCartAsync();
            CartContentUpdated.Invoke(this, new EventArgs { });
        }

        public Dictionary<Product, int> GetCartContent()
        {
            return new Dictionary<Product, int>(_cart.Products);
        }

        public int GetCartAmount()
        {
            return _cart.Products.Sum(p => p.Value);
        }

        public decimal GetCartTotal()
        {
            return _cart.Products.Sum(p => p.Value * p.Key.Price);
        }
        
        public async Task<List<(int userId, int amount, decimal totalPrice)>> GetAllActiveCarts()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CartDto>>("api/Cart");
            var activeCarts = new List<(int userId, int amount, decimal totalPrice)>();

            foreach (var cartDto in response)
            {
                //TODO Calculate totalprice here
                activeCarts.Add((cartDto.UserId, cartDto.Products.Sum(p => p.Amount), 0));
            }

            return activeCarts;
        }

        public async Task ClearCart()
        {
            _cart = new Cart();
            await SaveCartAsync();
            await GetCartAsync();
            CartContentUpdated.Invoke(this, new EventArgs { });
        }

        private async Task SaveCartAsync()
        {
            if (_userId is null) return;
            var cart = new List<ProductDto>();

            foreach (var productPair in _cart.Products)
            {
                cart.Add(new ProductDto()
                {
                    ProductId = productPair.Key.Id,
                    Amount = productPair.Value
                });
            }

            await _httpClient.PostAsJsonAsync($"api/Cart/{_userId}", cart);
        }

        public async Task<Cart?> BuildCartAsync(List<ProductDto>? cart, int userId)
        {
            if (cart is null) return null;
            var newCart = new Cart()
            {
                Products = new Dictionary<Product, int>(),
                UserId = userId,
                TotalPrice = 0
            };

            foreach (var productDto in cart)
            {
                //TODO: This can be optimized better
                var product = await _httpClient.GetFromJsonAsync<Product>($"api/Product/{productDto.ProductId}");
                if (product is null) continue;
                newCart.AddProduct(product, productDto.Amount);
            }

            return newCart;
        }
    }
}
