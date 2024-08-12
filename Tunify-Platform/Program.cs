using Microsoft.EntityFrameworkCore;
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

            builder.Services.AddScoped<IUsers, UsersServices>();
            builder.Services.AddScoped<ISongs, SongService>();
            builder.Services.AddScoped<IArtist, ArtistServices>();
            builder.Services.AddScoped<IPlayList, PlayListServices>();

            var app = builder.Build();
            app.MapControllers();

            app.MapGet("/", () => "Hello World!");
            app.MapGet("/new page", () => "Hello World!");

            app.Run();
        }
    }
}
