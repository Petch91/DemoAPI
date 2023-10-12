using DAL.Interfaces;
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
      private readonly IGameService _gameService;
      public GameController(IGameService gameService)
      {
         _gameService = gameService;
      }
      [HttpGet]
      public IActionResult GetAll()
      {
         return Ok(_gameService.ReadAll());
      }
      [HttpGet("{id}")]
      public IActionResult GetById(int id)
      {
         return Ok(_gameService.ReadOne(id));
      }
      [Authorize("AdminPolicy")]
      [HttpPost("add")]
      public IActionResult Add([FromBody] GameForm game)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         _gameService.Create(game.ToGame());
         return Ok();
      }
      [HttpPatch("edit/{id}")]
      public IActionResult Edit([FromBody] GameForm game, [FromRoute] int id)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         _gameService.Update(game.ToGame());
         return Ok();
      }
      [HttpDelete("{id}")]
      public IActionResult Delete(int id)
      {
         if (_gameService.Delete(id)) return Ok();
         return BadRequest();
      }
      //[HttpGet("byGenre")]
      //public IActionResult GetByGenre()
      //{
      //   return Ok(_gameService.GamesByGenre());
      //}
      [Authorize("IsConnected")]
      [HttpGet("Favoris/{userId}")]
      public IActionResult GetFav([FromRoute] int userId)
      {
         return Ok(_gameService.GetFavGames(userId));

      }
      [HttpPost("addFavori/{gameId}/user/{userId}")]
      public IActionResult AddFavori([FromRoute] int gameId, [FromRoute] int userId)
      {
         if (_gameService.ReadAll().Where(g => g.GameId == gameId).Count() == 0)
         {
            return BadRequest("ce jeu n'existe pas");
         }
         if(_gameService.GetFavGames(userId).Where(g => g.GameId == gameId).Count() != 0)
         {
            return BadRequest($"{_gameService.ReadOne(gameId).Title} est déjà dans les favoris");
         }
         _gameService.AddGameToFavList(userId, gameId);
         return Ok();
         
      }
   }
}
