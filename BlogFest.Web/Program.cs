using Microsoft.EntityFrameworkCore;
using BlogFest.Infrastructure.Persistance;
using static System.Net.Mime.MediaTypeNames;
using BlogFest.Web.Domain.Base;
using BlogFest.Web.Services.Identity;
using BlogFest.Services.FileStorage;
using BlogFest.Application;
using Microsoft.Extensions.FileProviders;
using BlogFest.Infrastruction.Persistance;
using BlogFest.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection, x => x.MigrationsAssembly("BlogFest.Infrastruction")));
services.AddDbContext<OldDataApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("EmailSettings"));

var fileStorageConfig = builder.Configuration.GetRequiredSection("FileStorage").Value;

if(fileStorageConfig == "DbSystem")
{
    //services.AddTransient<IFileStorageSystem, DbFileStorageSystem>();
}
else
{
    services.AddTransient<IFileStorageSystem, LocalFileStorageSystem>();
}

services.ConfigureServices();
services.Configure<DbConfigurationOptions>(x => x.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke(context);
    }
    catch (DomainException ex)
    {
        context.Response.StatusCode = StatusCodes.Status200OK;
        context.Response.ContentType = Application.Json;
        await context.Response.WriteAsJsonAsync(new
        {
            data = ex.Message,
            result = false
        });
    }
    catch (Exception ex)
    {
        if (!app.Environment.IsDevelopment())
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.Redirect("/Home/Error");
        }

        await next.Invoke(context);
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Content")),
    RequestPath = "/media"
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
