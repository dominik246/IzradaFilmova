using FluentValidation;

using IzradaFilmova.Database.Context;
using IzradaFilmova.Database.Functions;

using Microsoft.AspNetCore.Identity;

namespace IzradaFilmova
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Scan(scan =>
            {
                var callingAssembly = scan.FromCallingAssembly();
                callingAssembly.AddClasses(classes =>
                                           classes.AssignableTo(typeof(AbstractValidator<>)))
                               .AsSelf()
                               .WithTransientLifetime();
                callingAssembly.AddClasses(classes => classes.Where(@class => @class.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)))
                               .AsImplementedInterfaces()
                               .WithScopedLifetime();
                callingAssembly.AddClasses(classes => classes.Where(@class => @class.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase)))
                               .AsImplementedInterfaces()
                               .WithScopedLifetime();
            });

            builder.Services.AddDbContext<IzradaFilmovaDbContext>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication();
            builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<IzradaFilmovaDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                //app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.MapControllers();

            app.UseAuthentication();
            app.UseAuthorization();

            await app.SeedDatabaseDefaults();

            await app.RunAsync();
        }
    }
}