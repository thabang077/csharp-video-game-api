using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VideoGameApi.Data;


namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(DataContext context) : ControllerBase
    {

        private readonly DataContext _context = context;

        // Get all video games  
        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok( await _context.VideoGames.ToListAsync());
        }

        // Get video game by Id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        //Create a new video game
        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)

        {
            if (newGame == null)
                return BadRequest();

            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);

        }

        // Update an existing video game
        [HttpPut]
        [Route("{id}")]
        public async Task <ActionResult> UpdateVideoGame(int id, VideoGame updatedGame)
        {

            var game = await _context.VideoGames.FindAsync(id);

            if (game == null)
                return NotFound();

            game.Title = updatedGame.Title;
            game.Platform = updatedGame.Platform;
            game.Developer = updatedGame.Developer;
            game.Publisher = updatedGame.Publisher;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        // Delete a video game
        [HttpDelete]
        [Route("{id}")]

        public async Task <ActionResult> DeleteVideoGame(int id)
        {

            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
                return NotFound();

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
