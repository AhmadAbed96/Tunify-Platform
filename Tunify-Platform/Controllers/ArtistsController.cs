using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using Tunify_Platform.NewFolder;
using Tunify_Platform.Repositories.InterFace;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtist _artist;

        public ArtistsController(IArtist artist)
        {
            _artist = artist;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetAllArtist()
        {
            var AllArtist = await _artist.GetAllArtist();
            if (AllArtist == null) return NotFound();
            return Ok(AllArtist);
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(int id)
        {
            var  artist = await _artist.GetArtistById(id);
            if (artist == null) return NotFound();
            return Ok(artist);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if( id != artist.ArtistId)
            {
                return BadRequest();

            } 
            var Updateartist = await _artist.UpdateArtist( id, artist);
            if (Updateartist == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            var creatPlayList = await _artist.CreateArtist(artist);
            return Ok(creatPlayList);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {

            var deleteSong = await _artist.DeleteArtistById(id);
            if (deleteSong == null) return NotFound();
            return Ok();
        }
        // GET: api/Artists/GetSongsByArtist/1
        [HttpGet("GetSongsByArtist/{id}")]
        public async Task<ActionResult<IEnumerable<Songs>>> GetSongsByArtist(int id)
        {
            try
            {
                var songs = await _artist.GetArtistSongs(id);
                if (songs == null || !songs.Any())
                {
                    return NotFound();
                }
                return Ok(songs);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("artists/{artistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToArtist(int artistId, int songId)
        {
            try
            {
                var addSongToArtist = await _artist.AddSongTArtist(artistId, songId);
                return Ok(addSongToArtist);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
