using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using Tunify_Platform.NewFolder;
using Tunify_Platform.Repositories.InterFace;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            
            var ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Tunify_DbContext>(optionx => optionx.UseSqlServer(ConnectionStringVar));
             
            //Add Identity service 
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Tunify_DbContext>();
            builder.Services.AddScoped<IAccount, IdentityAccountServices>();
            builder.Services.AddScoped<IUsers, UsersServices>();
            builder.Services.AddScoped<ISongs, SongService>();
            builder.Services.AddScoped<IArtist, ArtistServices>();
            builder.Services.AddScoped<IPlayList, PlayListServices>();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
            });

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
            //call swagger services

            app.UseSwagger(
                  options =>
                  {
                      options.RouteTemplate = "api/{documentName}/swagger.json";
                  }
            );

            //call swagger UI

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");
            app.MapGet("/new page", () => "Hello World!");

            app.Run();


        }
    }
}
