using Tunify_Platform.NewFolder;
using Tunify_Platform.Repositories.InterFace;
using Tunify_Platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace Tunify_Platform.Repositories.Services
{
    public class PlayListServices : IPlayList
    {
        private readonly Tunify_DbContext _context;

        public PlayListServices(Tunify_DbContext context)
        {
            _context = context;
        }

        public async Task<PlayListSongs> AddSongToPlaylist(int songid, int playlistid)
        {
            var PlaylistSong = new PlayListSongs
            {
                SongsId = songid,
                PlaylistId = playlistid
            };
            _context.Entry(PlaylistSong).State = EntityState.Added;
            //await _tunifyDbContext.playlistSongs.AddAsync(PlaylistSong);
            await _context.SaveChangesAsync();
            return PlaylistSong;

        }

        public async Task<List<Songs>> GetPlayListSong(int id)
        {
            var playlistSongs = await _context.playListSongs
                .Where(p => p.PlaylistId == id)
                .Select(p => p.Song)
                .ToListAsync();
            return playlistSongs;
        } 

        public async Task<PlayList> CreatePlayList(PlayList playList)
        {
             _context.playList.Add(playList);
            await _context.SaveChangesAsync();

            return playList;
        }

        public async Task<PlayList> DeletePlayListById(int id)
        {
            var playList = await _context.playList.FirstAsync(u => u.PlayListId == id);
            if (playList == null)
            {
                return null;
            }
            _context.Entry(playList).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return playList;
        }

        public async Task<IEnumerable<PlayList>> GetAllPlayList()
        {
            return await _context.playList.ToListAsync();
        }

        public async Task<PlayList> GetPlayListById(int id)
        {
            var playList = await _context.playList.FindAsync(id);
            return playList;
        }

        public async Task<PlayList> UpdatePlayList(int id, PlayList playList)
        {
            _context.Entry(playList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!PlayListExists(id))
                {
                    return null;
                }
            }
            return playList;
        }
        private bool PlayListExists(int id)
        {
            return (_context.playList?.Any(e => e.PlayListId == id)).GetValueOrDefault();
        }
    }
}

