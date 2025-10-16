using Application.Common.Messages;
using Application.Contract;
using Domain.Entities.Identity;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;


public static class Cofiguration
{
    public static IServiceCollection Infrastructure
          (this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<SqlServerContext>(option =>
        {
            option.UseSqlServer(configuration.
                GetConnectionString("SqlServerConnection"),
                sqlServerOptionsAction: sqlConfig =>
                {
                    sqlConfig.EnableRetryOnFailure(

                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                        );
                });

        });
        service.AddIdentity<UserEntity, RoleEntity>().AddEntityFrameworkStores<SqlServerContext>()
       .AddRoles<RoleEntity>()
                        .AddDefaultTokenProviders().
                        AddErrorDescriber<PersianIdentityError>();
        service.Configure<IdentityOptions>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.User.RequireUniqueEmail = false;
        });
        #region Identity
        service.Configure<IdentityOptions>(option =>
        {
            option.User.RequireUniqueEmail = false;
            option.Password.RequireNonAlphanumeric = true;
            option.Password.RequiredLength = 6;
            option.SignIn.RequireConfirmedEmail = false;
            option.SignIn.RequireConfirmedAccount = false;
            option.SignIn.RequireConfirmedPhoneNumber = false;
            option.Lockout.MaxFailedAccessAttempts = 4;
            option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            option.User.RequireUniqueEmail = true;
            option.Password.RequireDigit = false;
            option.Password.RequireLowercase = false;
            option.Password.RequiredUniqueChars = 1;
            option.Password.RequireNonAlphanumeric = false;
            option.Password.RequireUppercase = false;
            option.Password.RequireLowercase = false;

        });
        service.ConfigureApplicationCookie(cooke =>
        {
            cooke.ExpireTimeSpan = TimeSpan.FromDays(30);
            cooke.LoginPath = "/SignIn";
            cooke.AccessDeniedPath = "/";
            cooke.SlidingExpiration = true;
        });
        #endregion

        return service;
    }
}