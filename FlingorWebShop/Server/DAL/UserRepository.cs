using FlingorWebShop.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlingorWebShop.Server.DAL;

public class UserRepository
{
    private readonly WebsiteDbContext _websiteDbContext;

    public UserRepository(WebsiteDbContext websiteDbContext)
    {
        _websiteDbContext = websiteDbContext;
        //TODO This is not needed after real database has been created.
        _websiteDbContext.Database.EnsureCreated();
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        return await _websiteDbContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await _websiteDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _websiteDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> CreateUser(User? user)
    {
        if (user is null)
        {
            return false;
        }

        //TODO Figure out how to make this into a guard-clause without having an error on row 49.d
        if (await GetUserByEmailAsync(user.Email) is null)
        {
            await _websiteDbContext.Users.AddAsync(user);
            await _websiteDbContext.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }
}

