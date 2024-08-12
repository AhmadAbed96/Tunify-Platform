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

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongs _song;

        public SongsController(ISongs song)
        {
            _song = song;
        }

        // GET: api/Songs
        [Route("/GetAllsongs")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Songs>>> GetAllsongs()
        {
            var AllSongs = await _song.GetAllSongs();
            if (AllSongs == null) return NotFound();
            
            return Ok(AllSongs);    
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Songs>> GetSongs(int id)
        {
          var song = await _song.GetSongById(id);
            if (song == null) return NotFound();
            return Ok(song);
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongs(int id, Songs songs)
        {
            if (songs.Id != id)
            {
                return BadRequest();
            }
            var UpdateSong = await _song.UpdateSong(id, songs);
            if (UpdateSong == null)
            {
                return NotFound();
            }
            return Ok(UpdateSong);
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Songs>> PostSongs(Songs songs)
        {
            return  await _song.CreateSong(songs);
            
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongs(int id)
        {
             var deleteSong = await _song.DeleteSongById(id);
            if (deleteSong == null) return NotFound();
            return Ok(deleteSong);
        }

        
    }
}
