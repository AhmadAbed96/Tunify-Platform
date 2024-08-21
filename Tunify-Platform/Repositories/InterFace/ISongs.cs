using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.InterFace
{
    public interface ISongs
    {
        public Task<IEnumerable<Songs>> GetAllSongs();

        Task<Songs> GetSongById(int id);
        Task UpdateSong(Songs song);
        Task DeleteSongById(int SongId);
        Task CreateSong(Songs song);
        
        
    }
}
