using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<Tunify_DbContext>().AddDefaultTokenProviders();
            builder.Services.AddScoped<IAccount, IdentityAccountServices>();
            builder.Services.AddScoped<IUsers, UsersServices>();
            builder.Services.AddScoped<ISongs, SongService>();
            builder.Services.AddScoped<IArtist, ArtistServices>();
            builder.Services.AddScoped<IPlayList, PlayListServices>();
            builder.Services.AddScoped<JwtTokenServices>();

            builder.Services.AddAuthentication(
                Options =>
                {
                    Options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                    Options =>
                    {
                        Options.TokenValidationParameters = JwtTokenServices.ValidateToken(builder.Configuration);
                    } );

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter user token below."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
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
