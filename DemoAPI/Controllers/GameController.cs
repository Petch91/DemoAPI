using DAL.Interfaces;
using DAL.Models;
using DemoAPI.Models;
using DemoAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class GameController : ControllerBase
   {
      private readonly IGameRepository _gameRepository;
      public GameController(IGameRepository gameRepository)
      {
         _gameRepository = gameRepository;
      }
      [HttpGet]
      public IActionResult GetAll()
      {
         return Ok(_gameRepository.ReadAll());
      }
      [HttpGet("{id}")]
      public IActionResult GetById(int id)
      {
         return Ok(_gameRepository.ReadOne(id));
      }
      [Authorize("AdminPolicy")]
      [HttpPost("add")]
      public IActionResult Add([FromBody] GameForm game)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         return Ok(_gameRepository.Create(game.ToGame()));
      }
      [HttpPatch("edit/{id}")]
      public IActionResult Edit([FromBody] GameForm game, [FromRoute] int id)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         _gameRepository.Update(game.ToGame());
         return Ok();
      }
      [HttpDelete("{id}")]
      public IActionResult Delete(int id)
      {
         if (_gameRepository.Delete(id)) return Ok();
         return BadRequest();
      }
      [HttpGet("byGenre")]
      public IActionResult GetByGenre()
      {
         return Ok(_gameRepository.GamesByGenre());
      }
      [Authorize("IsConnected")]
      [HttpGet("Favoris/{id}")]
      public IActionResult GetFav([FromRoute] Guid id)
      {
         return Ok(_gameRepository.GetFavGames(id));

      }
      [HttpPost("addFavori/{id}/user/{guid}")]
      public IActionResult AddFavori([FromRoute] int id, [FromRoute] Guid guid)
      {
         if (_gameRepository.ReadAll().Where(g => g.Id == id).Count() == 0)
         {
            return BadRequest("ce jeu n'existe pas");
         }
         if(_gameRepository.GetFavGames(guid).Where(g => g.Id == id).Count() != 0)
         {
            return BadRequest($"{_gameRepository.ReadOne(id).Title} est déjà dans les favoris");
         }
         _gameRepository.AddGameToFavList(guid, id);
         return Ok();
         
      }
   }
}
