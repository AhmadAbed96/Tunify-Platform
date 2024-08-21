using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public class PlayListsController : ControllerBase
    {
        private readonly IPlayList _playList;

        public PlayListsController(IPlayList playList)
        {
            _playList = playList;
        }

        // GET: api/PlayLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayList>>> GetAllplayList()
        {
            var AllplayLists = await _playList.GetAllPlayList();

            if (AllplayLists == null) return NotFound();
            return Ok(AllplayLists);
        }




        [HttpPost("{songId}/songs/{playlistId}")]
        //[Route("{songId}/songs/{playlistId}")]


        public async Task<IActionResult> AddSongToPlayList(int songId, int playlistId)
        {
            var playList = await _playList.AddSongToPlaylist(songId, playlistId);
            if (playList == null) return NotFound();
            return Ok();
        }

        [HttpGet("{playlistId}/AllSongs")]
        public async Task<ActionResult<List<Songs>>> GetPlayListSong(int playlistId)
        {
            var Song = await _playList.GetPlayListSong(playlistId);
            return Song;
        }


        // GET: api/PlayLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayList>> GetPlayList(int id)
        {
            var playList = await _playList.GetPlayListById(id);
            if (playList == null) return NotFound();            
          
            return Ok(playList);
        }

        // PUT: api/PlayLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayList(int id, PlayList playList)
        {
            
            if (id != playList.PlayListId)
            {
                return BadRequest();
            }

            var updatePlayList = await _playList.UpdatePlayList(id, playList);
            if (updatePlayList == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/PlayLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayList>> PostPlayList(PlayList playList)
        {
            var creatPlayList = await _playList.CreatePlayList(playList);
            return Ok(creatPlayList);
        }

        // DELETE: api/PlayLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayList(int id)
        {
            var deleteSong = await _playList.DeletePlayListById(id);
            if (deleteSong == null) return NotFound();
            return Ok(deleteSong);
        }

       
        // GET: api/Playlists/{playlistId}/songs
        [HttpGet("{playlistId}/songs")]
        public async Task<IActionResult> GetSongsInPlaylist(int playlistId)
        {
            try
            {
                var songs = await _playList.GetPlayListSong(playlistId);

                if (songs == null || !songs.Any())
                {
                    return NotFound("No songs found for this playlist.");
                }

                return Ok(songs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
