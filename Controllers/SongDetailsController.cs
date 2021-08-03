using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongDetailsAPI.Models;
using SongDetailsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongDetailsController : ControllerBase
    {
        private readonly ISongDetailsRepos _songDetailsRepo;

        public SongDetailsController(ISongDetailsRepos songDetailsRepos)
        {
            _songDetailsRepo = songDetailsRepos;
        }

        [HttpGet]
        public IEnumerable<SongDetails> GetAllSongDetails()
        {
            return _songDetailsRepo.GetAllSongsDetails();
        }

        [HttpGet("{id}")]
        public IActionResult GetSongDetailsById(int id)
        {
            try
            {
                var songDetails = _songDetailsRepo.GetSongDetailsById(id);
                if(songDetails == null)
                {
                    return NotFound();
                }
                return Ok(songDetails);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostSong(SongDetails item)
        {
            try
            {
                var addSong = await _songDetailsRepo.PostSongDetails(item);
                return Ok(addSong);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateSong(int id, SongDetails item)
        {
            try
            {
                var updateSong = await _songDetailsRepo.UpdateSongDetails(id, item);
                return Ok(updateSong);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            try
            {
                var deleteSong = await _songDetailsRepo.DeleteSong(id);
                return Ok(deleteSong);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
