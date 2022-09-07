using FluentValidation;

using IzradaFilmova.Database.Context;

using Microsoft.AspNetCore.Identity;

namespace IzradaFilmova
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Scan(scan =>
                                  scan.FromCallingAssembly()
                                      .AddClasses(classes =>
                                                  classes.AssignableTo(typeof(AbstractValidator<>)))
                                      .AsSelf()
                                      .WithTransientLifetime());
            builder.Services.AddDbContext<IzradaFilmovaDbContext>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}