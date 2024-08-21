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

        public async Task CreateSong(Songs song)
        {
           var songs = _context.songs.Add(song);
            await _context.SaveChangesAsync();
           
        }

        public async Task DeleteSongById(int SongId)
        {           
            var song = await _context.songs.FirstAsync(u => u.Id == SongId);
            if (song != null)
            {
            _context.Entry(song).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            }
            
        }

        public async Task<IEnumerable<Songs>> GetAllSongs()
        {
            var AllSongs = await _context.songs.ToListAsync();
            return AllSongs;
        }

        

        public async Task<Songs> GetSongById(int id)
        {
            var song = await _context.songs.FindAsync(id);
            return song;
            

        }

        public async Task UpdateSong(Songs song)
        {
            _context.Entry(song).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
       

    }
}
