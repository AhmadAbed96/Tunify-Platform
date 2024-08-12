using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.InterFace
{
    public interface ISongs
    {
        public Task<IEnumerable<Songs>> GetAllSongs();

        Task<Songs> GetSongById(int id);
        Task<Songs> UpdateSong(int SongId, Songs song);
        Task<Songs> DeleteSongById(int SongId);
        Task<Songs> CreateSong(Songs song);
    }
}
