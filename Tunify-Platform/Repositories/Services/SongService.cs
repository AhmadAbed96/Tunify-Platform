using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using Tunify_Platform.NewFolder;
using Tunify_Platform.Repositories.InterFace;

namespace Tunify_Platform.Repositories.Services
{
    public class SongService : ISongs
    {
        private readonly Tunify_DbContext _context;

        public SongService(Tunify_DbContext context)
        {
            _context = context;
        }

        public async Task<Songs> AddSongToArtist(int artistId, int songId)
        {
            {
                var song = await _context.songs.FirstOrDefaultAsync(e => e.Id == songId);
                song.ArtistId = artistId;
                await _context.SaveChangesAsync();
                return song;

            }
        }

        public async Task<Songs> CreateSong(Songs song)
        {
            _context.songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public Task<Songs> CreateSong(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Songs> DeleteSongById(int SongId)
        {           
            var song = await _context.songs.FirstAsync(u => u.Id == SongId);
            if (song == null)
            {
                return null;
            }
            _context.Entry(song).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<IEnumerable<Songs>> GetAllSongs()
        {
            return await _context.songs.ToListAsync();
        }

        public async Task<List<Songs>> GetAllsongsbyanartists(int ArtistId)
        {
            List<Songs> AllSongs = await _context
               .songs
               .Where(e => e.ArtistId == ArtistId).ToListAsync();

            if (AllSongs.Count == 0) return null;

            return AllSongs;
        }

        public async Task<Songs> GetSongById(int id)
        {
            var song = await _context.songs.FindAsync(id);
            return song;
            

        }

        public async Task<Songs> UpdateSong(int SongId, Songs song)
        {
            _context.Entry(song).State = EntityState.Modified;
            try
            {
                await _context.SavedChangesAsync();
            }
            catch (DbUpdateException) 
            {
                if (!SongExists(SongId))
                {
                    return null;
                }
            }
            return song;
        }
        private bool SongExists(int id)
        {
            return (_context.songs?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
