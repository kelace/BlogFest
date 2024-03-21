using BlogFest.Application.Abstract;
using BlogFest.Application.Shared;
using BlogFest.Application;
using BlogFest.Data;
using BlogFest.Domain.Administration;
using BlogFest.Domain.Content.ContentConsuming;
using BlogFest.Domain.Content.ContentCreating;
using BlogFest.Domain.NotificationUser;
using BlogFest.Domain.Users;
using BlogFest.Infrastruction.Files;
using BlogFest.Infrastruction.ImageResizer.Strategy;
using BlogFest.Infrastruction.ImageResizer;
using BlogFest.Infrastruction.Persistance.Repositories;
using BlogFest.Infrastruction.SlugCreator;
using BlogFest.Infrastruction;
using BlogFest.Infrastructure.Persistance.Repositories;
using BlogFest.Infrastructure.Persistance;
using BlogFest.Web.Filters;
using BlogFest.Web.Services.Identity;
using BlogFest.Web.Services;
using BlogFest.Services.UserContext;
using BlogFest.Web.Services.Email;
using BlogFest.Infrastruction.Authtorization;
using Microsoft.AspNetCore.Identity;
using BlogFest.Application.Behaviors;
using MediatR;

namespace BlogFest.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson();

            services.AddScoped<IDomainEventStorage, DomainEventStorage>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IContentCreatorRepository, ContentCreatorRepository>();
            services.AddTransient<IContentConsumerRepository, ContentConsumerRepository>();
            services.AddTransient<IManagerRepository, ManagerRepository>();
            services.AddTransient<IApplicationAuthentication, AppIdentityService>();
            services.AddTransient<IUserContext, UserContext>();
            services.AddScoped<IDomainEventStorage, DomainEventStorage>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IWebHostEnvironmentAccessor, WebHostEnvironmentAccessor>();
            services.AddTransient<IImageResizer, ImageResizer>();
            services.AddTransient<IUserImageLoader, UserImageService>();
            services.AddTransient<IPostImageLoader, PostImageLoader>();
            services.AddTransient<ISlugCreator, SlugCreator>();
            services.AddTransient<IUserNotificationRepository, UserNotificationRepository>();
            services.AddTransient<IFileExtensionChecker, FileExtensionChecker>();
            services.AddScoped<DefaultValidateModelAttribute>();
            services.AddTransient<Dictionary<ResizeType, IResizeStrategy>>(x =>
            {
                var strategies = new Dictionary<ResizeType, IResizeStrategy>();

                strategies[ResizeType.Default] = new DefaultResizeStrategy();
                strategies[ResizeType.Cover] = new CoverResizeStrategy();

                return strategies;
            });

            services.AddIdentity<AuthUser, AuthIdentityRole>(options =>
            {
                options.Lockout.AllowedForNewUsers = false;
                options.User.RequireUniqueEmail = true;
            }).AddErrorDescriber<ErrorDescriber>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/authorization/signin";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(0.5);
                options.SlidingExpiration = true;
            });

            services.AddHttpContextAccessor();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RefreshCacheBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DbTransactionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationHook).Assembly));

            services.AddAutoMapper(typeof(ApplicationHook), typeof(Program));

            services.AddMemoryCache();
        }
    }
}
