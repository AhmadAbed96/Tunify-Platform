﻿using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.InterFace
{
    public interface IArtist
    {
         Task<IEnumerable<Artist>> GetAllArtist();

        Task<Artist> GetArtistById(int id);
        Task<Artist> UpdateArtist(int id, Artist artist);
        Task<Artist> DeleteArtistById(int id);
        Task<Artist> CreateArtist(Artist artist);
        Task<Songs> AddSongTArtist(int song, int artist);
        Task<List<Songs>> GetArtistSongs(int id);
    }
}
