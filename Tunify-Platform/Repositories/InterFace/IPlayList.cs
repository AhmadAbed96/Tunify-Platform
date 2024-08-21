using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.InterFace
{
    public interface IPlayList
    {
        public Task<IEnumerable<PlayList>> GetAllPlayList();

        Task<PlayList> GetPlayListById(int id);
        Task<PlayList> UpdatePlayList(int id, PlayList playList);
        Task<PlayList> DeletePlayListById(int id);
        Task<PlayList> CreatePlayList(PlayList playList);
        Task<PlayListSongs> AddSongToPlaylist(int songid, int playlistid);
        Task<List<Songs>> GetPlayListSong(int id);
    }
}
