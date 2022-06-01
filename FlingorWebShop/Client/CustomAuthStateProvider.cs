using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using FlingorWebShop.Client.DAL;
using FlingorWebShop.Shared;
using Microsoft.IdentityModel.Tokens;

namespace FlingorWebShop.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly UserManager _userManager;
        private readonly HttpClient _httpClient;
        private readonly CartManager _cartManager;

        public CustomAuthStateProvider(ILocalStorageService localStorage, UserManager userManager, HttpClient httpClient, CartManager cartManager)
        {
            _localStorage = localStorage;
            _userManager = userManager;
            _httpClient = httpClient;
            _cartManager = cartManager;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorage.GetItemAsStringAsync("token");

            var identity = new ClaimsIdentity();

            //If there already is a token in localstorage, parse the token and set the logged in user to the one that matched he Email claim.
            if (!string.IsNullOrEmpty(token))
            {
                identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

                //If there is a token in localstorage but no user with the same Email claim, this causes errors. If the try fails, remove the token altogether. 
                try
                {
                    var existingUser = await _httpClient
                        .GetFromJsonAsync<User>($"api/user/find/{identity.Claims.First(c => c.Type.Contains("emailaddress")).Value}");
                    if (existingUser is not null)
                    {
                        _userManager.SetUser(existingUser);
                    }
                    _cartManager.SetUserId(existingUser.Id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    await _localStorage.RemoveItemAsync("token");
                    identity = new ClaimsIdentity();
                    _cartManager.ResetUserId();
                }
            }
            else
            {
                _cartManager.ResetUserId();
            }

            await _cartManager.GetCartAsync();

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
