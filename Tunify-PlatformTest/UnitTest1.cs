using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.NewFolder;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.InterFace;
using Tunify_Platform.Repositories.Services;
using Xunit;

namespace TunifyTest
{
    public class UnitTest1
    {
        private readonly Tunify_DbContext _tunifyDbContext;
        private readonly PlayListServices playList;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<Tunify_DbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDatabase")
                            .Options;

            _tunifyDbContext = new Tunify_DbContext(options);
            playList = new PlayListServices(_tunifyDbContext);
        }

        [Fact]
        public async Task GetSongsForPlaylistTest()
        {
            // Arrange: Add playlist-song relationships to the in-memory database

            _tunifyDbContext.songs.AddRange(new List<Songs> {
                new Songs {Id = 1 , Title = "Billie Jean" ,    ArtistId = 1 , AlbumId = 1 , Genre = "Rock"    , Duration = new TimeSpan(0 , 33 , 55)},
                new Songs {Id = 2 , Title = "Bohemian Rhapsody" , ArtistId = 2 , AlbumId = 2 , Genre = "Rock", Duration = new TimeSpan(0 , 55 , 55)},
                new Songs {Id = 3 , Title = "Bohemian Rhapsody" , ArtistId = 2 , AlbumId = 2 , Genre = "Rock", Duration = new TimeSpan(0 , 55 , 55)},
                new Songs {Id = 4 , Title = "Bohemian Rhapsody" , ArtistId = 2 , AlbumId = 2 , Genre = "Rock", Duration = new TimeSpan(0 , 55 , 55)}
            });

            _tunifyDbContext.playList.AddRange(new List<PlayList> {
                new PlayList{PlayListId = 1,PlayList_Name = "Rock Classics",Created_date  =  "21/4/2023" , UserId = 1 },
                new PlayList{PlayListId = 2,PlayList_Name = "Pop Hits",     Created_date  =  "24/4/2023" , UserId = 2},
                new PlayList{PlayListId = 3,PlayList_Name = "Pop Hits",     Created_date  =  "26/4/2023" , UserId = 3}

            });
            _tunifyDbContext.playListSongs.Add(new PlayListSongs { PlaylistId = 1, SongsId = 3 });
            _tunifyDbContext.playListSongs.Add(new PlayListSongs { PlaylistId = 1, SongsId = 4 });
            await _tunifyDbContext.SaveChangesAsync();

            // Act: Retrieve songs for the given playlist ID
            var result = await playList.GetPlayListSong(1);

            // Assert: Verify the results
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}