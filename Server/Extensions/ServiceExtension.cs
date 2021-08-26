using Azure.Storage.Blobs;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Models;
using KnowledgeBase.Server.Persistence;
using KnowledgeBase.Server.Repositories;
using KnowledgeBase.Server.Services;
using KnowledgeBase.Server.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;

namespace KnowledgeBase.Server.Extensions
{
    public static class ServiceExtension
    {
        public static void AddB2CAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAdB2C"));
        }

        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureIdentityOptions(this IServiceCollection services)
        {
            services.AddScoped(sp =>
            {
                var context = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
                var identityOptions = new IdentityOptions();

                if (context.User.Identity.IsAuthenticated)
                {
                    identityOptions.User = context.User;

                    // TODO: Configure other identity options
                }

                return identityOptions;
            });
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, AzureBlobStorageService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IDashboardService, DashboardService>();
        }

        public static void AddAzureStorageSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureStorageSetting>(configuration.GetSection(nameof(AzureStorageSetting)));
        }

        public static void AddAzureStorageClient(this IServiceCollection services)
        {
            services.AddScoped(serviceProvider =>
            {
                var azureStorageSetting = serviceProvider.GetRequiredService<IOptions<AzureStorageSetting>>().Value;
                return new BlobServiceClient(azureStorageSetting.StorageConnectionString);
            });
        }
    }
}