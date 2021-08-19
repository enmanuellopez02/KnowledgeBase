using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using KnowledgeBase.Shared.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace KnowledgeBase.Client.Infraestructure
{
    public class AzureADB2CUserFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {
        private readonly IHttpClientFactory _httpClient;

        public AzureADB2CUserFactory(IAccessTokenProviderAccessor tokenProviderAccessor, IHttpClientFactory httpClient) : base(tokenProviderAccessor)
        {
           _httpClient = httpClient;
        }

        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
        {
            var initialUser = await base.CreateUserAsync(account, options);

            if (initialUser.Identity.IsAuthenticated)
            {
                var userIdentity = initialUser.Identity as ClaimsIdentity;

                using var httpClient = _httpClient.CreateClient("KnowledgeBase.ServerAPI");
                var response = await httpClient.GetAsync("api/userprofiles");

                if (response.IsSuccessStatusCode)
                {
                    var userProfile = await response.Content.ReadFromJsonAsync<UserProfileDetail>();
                    var roleName = userProfile.IsAdmin ? "Admin" : "User";
                    userIdentity.AddClaim(new Claim(ClaimTypes.Role, roleName));
                }
            }

            return initialUser;
        }
    }
}