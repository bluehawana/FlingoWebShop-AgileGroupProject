using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlingorWebShop.Shared;

/// <summary>
/// Class <c>Cart</c> represents a shopping cart that has a Dictionary as container of products.
/// </summary>
public class Cart
{
    /// <value>Property <c>Products</c> represents a list of products that are in the shopping cart. Product is the Key and int the quantity.</value>
    public Dictionary<Product, int> Products { get; set; } = new Dictionary<Product, int>();

    /// <summary>
    /// Id of user connected to cart
    /// </summary>
    public int? UserId { get; set; }

    //TODO: REMOVE
    public decimal TotalPrice { get; set; }

    /// <summary>
    /// Adds a quantity of product to Products based on Product.Id.
    /// </summary>
    /// <param name="product"></param>
    /// <param name="quantity"></param>
    public void AddProduct(Product product, int quantity = 1)
    {
        foreach (KeyValuePair<Product, int> item in Products)
        {
            // If there is a product with the same Id in the Dictionary Products then update the quantity.
            if (item.Key.Id == product.Id)
            {
                Products[item.Key] += quantity;

                // Return in order to not add another Product!!
                return;
            }
        }

        Products.Add(product, quantity);
    }

    /// <summary>
    /// Deletes a quantity of a specific product from Products.
    /// </summary>
    /// <param name="product"></param>
    /// <param name="quantity"></param>
    public void DeleteProduct(int productId, int quantity = 1)
    {
        if (Products.All(p => p.Key.Id != productId))
        {
            return;
        }

        var product = Products.First(p => p.Key.Id == productId).Key;

        if (Products[product] > quantity)
        {
            Products[product] -= quantity;

            return;
        }

        Products.Remove(product);
    }
}
