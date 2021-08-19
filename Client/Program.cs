using System;
using System.Net.Http;
using System.Threading.Tasks;
using KnowledgeBase.Client.Infraestructure;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KnowledgeBase.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("KnowledgeBase.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("KnowledgeBase.ServerAPI"));
            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
                options.ProviderOptions.DefaultAccessTokenScopes.Add("https://evospike.onmicrosoft.com/46a6f571-94d6-47b5-baab-38eca345d3e3/Api.ReadWrite");
                options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
                options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
                options.ProviderOptions.LoginMode = "redirect";
            })
                .AddAccountClaimsPrincipalFactory<AzureADB2CUserFactory>(); // Add custom role claim

            await builder.Build().RunAsync();
        }
    }
}