using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Tunify_Platform.Models;
using Tunify_Platform.NewFolder;
using Tunify_Platform.Repositories.InterFace;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistServices : IArtist
    {

        private readonly Tunify_DbContext _context;

        public ArtistServices(Tunify_DbContext context)
        {
            _context = context;
        }
        public async Task<Artist> CreateArtist(Artist artist)
        {
             _context.artist.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<IEnumerable<Artist>> GetAllArtist()
        {
            return await _context.artist.ToListAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            var artist = await _context.artist.FindAsync(id);
            return artist;
        }

        public async Task<Artist> UpdateArtist(int id, Artist artist)
        {
            _context.Entry(artist).State = EntityState.Modified;
            try
            {
                await artist.SaveChangesASync();
            }
            catch (DbException)
            {
                if (!ArtisttExist(id))
                {
                    return null;
                }
            }
            return artist;
        }
        private bool ArtisttExist(int id)
        {
            return (_context.playList?.Any(e => e.PlayListId == id)).GetValueOrDefault();
        }


        public async Task<Artist> DeleteArtistById(int id)
        {
            var artist = await _context.artist.FirstAsync(n => n.ArtistId == id);
            if (artist == null)
            {
                return null;
            }
            _context.Entry(artist).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return artist;
        }

        public Task<Songs> AddSongTArtist(int songId, int artistId)
        {
            Songs ArtistSong = new Songs()
            {
                ArtistId = songId,
                Id = songId
            };
            _context.Entry(ArtistSong).State = EntityState.Added;
            await _context.SaveChangesAsync();
            var artistsong = await GetArtistById(artistId);
            return ArtistSong;
        }

        public Task<List<Songs>> GetArtistSongs(int id)
        {
            var S = await _context.playListSongs
                .Where(p => p.PlaylistId == id)
                .Select(p => p.Song)
                .ToListAsync();
            return playlistSongs;
        }
    }
}
