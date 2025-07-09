using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame 
            {
                Id = 1, 
                Title = "The Legend of Zelda: Breath of the Wild", 
                Platform = "Nintendo Switch", 
                Developer = "Nintendo EPD", 
                Publisher = "Nintendo" 
            },
            new VideoGame 
            { 
                Id = 2,
                Title = "God of War", 
                Platform = "PlayStation 4", 
                Developer = "Santa Monica Studio", 
                Publisher = "Sony Interactive Entertainment" 
            },
            new VideoGame 
            { 
                Id = 3, 
                Title = "Minecraft", 
                Platform = "Multi-platform", 
                Developer = "Mojang Studios", 
                Publisher = "Mojang Studios" 
            }
        };

        // Get all video games
        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }

        //Get a video game by ID
        [HttpGet]
        [Route("{id}")]
        public ActionResult<VideoGame> GetVideoGameById(int id)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        //Create a new video game
        [HttpPost]
        public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)

        {
            if (newGame == null)
                return BadRequest();

            newGame.Id = videoGames.Max(g => g.Id) + 1;
            videoGames.Add(newGame);
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);

        }



    }
}
