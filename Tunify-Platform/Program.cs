using Microsoft.EntityFrameworkCore;
using Tunify_Platform.NewFolder;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Tunify_DbContext>(optionx => optionx.UseSqlServer(ConnectionStringVar));
            var app = builder.Build();


            app.MapGet("/", () => "Hello World!");
            app.MapGet("/new page", () => "Hello World!");

            app.Run();
        }
    }
}
