using DAL;
using DAL.Interfaces;
using DemoAPI.Models;
using DemoAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class GenreController : ControllerBase
   {
      private readonly IGenreService _genreService;
      public GenreController(IGenreService genreService)
      {
         _genreService = genreService;
      }

      [HttpGet]
      public IActionResult GetAll() 
      {
         return Ok(_genreService.ReadAll());
      }
      [HttpPost("add")]
      public IActionResult Add([FromBody] GenreForm genre)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         _genreService.Create(genre.ToGenre());
         return Ok();
      }
      [HttpDelete("{id}")]
      public IActionResult Delete(int id)
      {
         if (_genreService.Delete(id)) return Ok();
         return BadRequest();
      }
   }
}
