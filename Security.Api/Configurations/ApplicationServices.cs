using Microsoft.EntityFrameworkCore;
using Security.Application.Interface;
using Security.Application.Services;
using Security.Domain;
using Security.Domain.Repository;
using Security.Domain.UnitOfWork;

namespace Security.Api.Configurations
{
    public static class ApplicationServices
    {
        public static void AddCustomApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TokenDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("UserDbConnection"));
            });
            services.AddTransient<ITokenHandler, TokenHandler>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICreateToken, CreateToken>();
            services.AddTransient<IUpdateToken, UpdateToken>();
            services.AddTransient<IDeleteToken, DeleteToken>();
            services.AddTransient<IReturnAll, ReturnAll>();


        }
    }
}
