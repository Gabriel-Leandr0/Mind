using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mind.Application.Interfaces;
using Mind.Application.Services;
using Mind.Domain.ViewModels;
using Mind.Infrastructure.Data;
using Mind.Infrastructure.Encryption;
using Mind.Infrastructure.Profiles;
using Mind.Infrastructure.Session;
using Mind.Infrastructure.Token;
using Mind.Read.Interface;
using Mind.Read.Queries;

public static class DependencyInjection
{
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        // Database connections
        services.AddDbContext<MindDbContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("MindConnection")));

        //UTILS
        services.AddSingleton<ITokenService<UserViewModel>, TokenService>();
        services.AddSingleton<IEncryptionService, EncryptionService>();
        services.AddTransient<DbSession>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<TokenService>();

        //Queries
        services.AddScoped<IUserQuery, UserQuery>();

        //Services
        services.AddScoped<IUserService, UserService>();

        //AutoMapper
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UserProfile());
            mc.AddProfile(new RoleProfile());
            mc.AddProfile(new ProjectProfile());
            mc.AddProfile(new CategoryProfile());
        });
    }
}
