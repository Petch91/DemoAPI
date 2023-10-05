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
      private readonly IGenreRepository _genreRepository;
      public GenreController(IGenreRepository genreRepository)
      {
         _genreRepository = genreRepository;
      }

      [HttpGet]
      public IActionResult GetAll() 
      {
         return Ok(_genreRepository.ReadAll());
      }
      [HttpPost("add")]
      public IActionResult Add([FromBody] GenreForm genre)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         _genreRepository.Create(genre.ToGenre());
         return Ok();
      }
      [HttpDelete("{id}")]
      public IActionResult Delete(int id)
      {
         if (_genreRepository.Delete(id)) return Ok();
         return BadRequest();
      }
   }
}
