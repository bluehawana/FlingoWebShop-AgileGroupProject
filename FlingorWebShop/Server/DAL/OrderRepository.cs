using FlingorWebShop.Shared;
using Microsoft.EntityFrameworkCore;

namespace FlingorWebShop.Server.DAL;

public class OrderRepository
{
    private readonly WebsiteDbContext _websiteDbContext;

    public OrderRepository(WebsiteDbContext websiteDbContext)
    {
        _websiteDbContext = websiteDbContext;
        //TODO This is not needed after real database has been created.
        _websiteDbContext.Database.EnsureCreated();
    }

    public async Task<ICollection<Order>> GetAllOrdersAsync()
    {
        return await _websiteDbContext.Orders.Include(o => o.OrderDetails).ToListAsync();
    }

    public async Task<Order?> GetOrderAsync(int id)
    {
        return await _websiteDbContext.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<ICollection<Order>?> GetAllOrderOfOneUserAsync(int userId)
    {
        return await _websiteDbContext.Orders.Include(o => o.OrderDetails).Where(o => o.UserId == userId).ToListAsync();
    }

    public async Task<bool> CreateOrder(Order? order)
    {
        if (order is null) return false;

        if (await GetOrderAsync(order.Id) is not null) return false;

        await _websiteDbContext.Orders.AddAsync(order);
        await _websiteDbContext.SaveChangesAsync();
        return true;
    }
}