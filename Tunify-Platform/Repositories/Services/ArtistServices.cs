﻿using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Security.Policy;
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
                await _context.SaveChangesAsync();
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

        public async Task<Songs> AddSongTArtist(int songId, int artistId)
        {
            var song = await _context.songs.FirstOrDefaultAsync(e => e.Id == songId);
            song.ArtistId = artistId;
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<List<Songs>> GetArtistSongs(int id)
        {
            List<Songs> AllSongs = await _context.songs
            .Where(e => e.ArtistId == id)
            .ToListAsync();

            if (AllSongs.Count == 0) return null;

            return AllSongs;
        }
       

    }
}
