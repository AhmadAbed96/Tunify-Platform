using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Tunify_Platform.Models;

namespace Tunify_Platform.NewFolder
{
    public class Tunify_DbContext : DbContext
    {
        public Tunify_DbContext(DbContextOptions options) : base(options) 
        {
               
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Subscription> subscriptions { get; set; }
        public DbSet<Artist> artist { get; set; }
        public DbSet<Album> album { get; set; }
        public DbSet<PlayList> playList { get; set; }
        public DbSet<PlayListSongs> playListSongs { get; set; }
        public DbSet<Songs> songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Subscription)
                .WithOne(u => u.users)
                .HasForeignKey<Users>(u => u.SubId)
                .IsRequired(false);

            modelBuilder.Entity<PlayList>()
                .HasOne(p => p.user)
                .WithMany(u => u.playLists)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Songs>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.songs)
                .HasForeignKey(s => s.ArtistId);

            modelBuilder.Entity<Songs>()
                .HasOne(s => s.Album)
                .WithMany(a => a.songs)
                .HasForeignKey(s => s.AlbumId);

            modelBuilder.Entity<PlayListSongs>()
                .HasKey(ps => new { ps.PlaylistId, ps.SongsId });

            modelBuilder.Entity<PlayListSongs>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlayListSongs)
                .HasForeignKey(ps => ps.PlaylistId);

            modelBuilder.Entity<PlayListSongs>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongsId);

            modelBuilder.Entity<PlayListSongs>().HasData(
                new PlayListSongs { SongsId = 1, PlaylistId = 2 },
                new PlayListSongs { SongsId = 1, PlaylistId = 1 },
                new PlayListSongs { SongsId = 2, PlaylistId = 2 }

                );

            modelBuilder.Entity<Subscription>().HasData(new List<Subscription>
             {
                 new Subscription{ SubscriptionId = 1, Subscription_Type = "gold", Price = 50},
                 new Subscription{ SubscriptionId = 2, Subscription_Type = "selver", Price = 25},
                 new Subscription{ SubscriptionId = 3, Subscription_Type = "bronz", Price = 20}


             });



            modelBuilder.Entity<Users>().HasData(
               new Users { UsersId = 1, UserName = "Abed", Email = "Abed@example.com", Join_Date = "20/4/2023", SubId = 1 },
               new Users { UsersId = 2, UserName = "Samer", Email = "Samer@example.com", Join_Date = "21/4/2023", SubId = 2 },
               new Users { UsersId = 3, UserName = "khaled", Email = "khaled@example.com", Join_Date = "20/4/2023", SubId = 3 }
           );
            modelBuilder.Entity<Artist>().HasData(
               new Artist { ArtistId = 1, Name = "Artist 1" },
               new Artist { ArtistId = 2, Name = "Artist 2" },
               new Artist { ArtistId = 3, Name = "Artist 3" }
           );

            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = 1, AlbumName = "Album 1" , Release_Date = "20/4/2023" },
                new Album { AlbumId = 2, AlbumName = "Album 2" , Release_Date = "21/4/2023" },
                new Album { AlbumId = 3, AlbumName = "Album 3" , Release_Date = "20/4/2023" }
               
            );

            modelBuilder.Entity<Songs>().HasData(
                new Songs { Id = 1, Title = "Song 1", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(3), Genre = "Pop" },
                new Songs { Id = 2, Title = "Song 2", ArtistId = 2, AlbumId = 2, Duration = TimeSpan.FromMinutes(4), Genre = "Rock" },
                new Songs { Id = 3, Title = "Song 3", ArtistId = 3, AlbumId = 3, Duration = TimeSpan.FromMinutes(5), Genre = "Jazz" }
               
            );

            modelBuilder.Entity<PlayList>().HasData(
                new PlayList { PlayListId = 1, PlayList_Name = "Playlist 1", UserId = 1 },
                new PlayList { PlayListId = 2, PlayList_Name = "Playlist 2", UserId = 2 },
                new PlayList { PlayListId = 3, PlayList_Name = "Playlist 3", UserId = 3 }
               
            );

        }

        internal async Task SavedChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
