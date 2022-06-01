using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using FlingorWebShop.Server.DAL;
using FlingorWebShop.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FlingorWebShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        //TODO Should use Repo?
        private WebsiteDbContext _websiteDbContext;
        private UserRepository _userRepository;


        public AuthController(IConfiguration configuration, UserRepository userRepository, WebsiteDbContext websiteDbContext)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _websiteDbContext = websiteDbContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User request)
        {
            var user = request;
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            if (await _userRepository.CreateUser(user))
            {
                return Ok(user);
            }
            return BadRequest(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var existingUser = await _websiteDbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser is null)
            {
                return BadRequest("User not found.");
            }

            if (existingUser.Email != request.Email)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, existingUser.PasswordHash, existingUser.PasswordSalt))
            { 
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(existingUser);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Actor, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.MobilePhone ,user.Phone),
                new Claim(ClaimTypes.StreetAddress ,$"{user.StreetName} {user.StreetNumber}, {user.City}"),
                new Claim(ClaimTypes.PostalCode ,user.PostalCode),
                new Claim(ClaimTypes.StateOrProvince ,user.State ?? ""),
                new Claim(ClaimTypes.Country ,user.Country),
                new Claim(ClaimTypes.Email, user.Email),
            };
            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));

            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
