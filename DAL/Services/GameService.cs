using DAL.Domains;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
   public class GameService : IGameService
   {
      private readonly DataContext _context;
      public GameService(DataContext dataContext)
      {
         _context = dataContext;
      }
      public Game Create(Game entity)
      {
         _context.games.Add(entity);
         _context.SaveChanges();
         Game newGame = _context.games.OrderBy(x => x.GameId).Last();
         _context.gameGenres.Add(new GameGenre
         {
            GameId = newGame.GameId,
            GenreId = entity.GenreId
         });
         _context.SaveChanges();
         return newGame ;
      }

      public bool Delete(int id)
      {
         Game game = _context.games.FirstOrDefault(g => g.GameId == id);
         if (game != null)
         {
            _context.gameGenres.RemoveRange(_context.gameGenres.Where(g =>g.GameId == id));
            _context.games.Remove(game);
            _context.SaveChanges();
            return true;
         }
         return false;
      }

      public IEnumerable<Game> ReadAll()
      {
         return _context.games;
      }

      public Game ReadOne(int id)
      {
         return _context.games.FirstOrDefault(g => g.GameId == id);
      }

      public bool Update(Game entity)
      {
         Game game = _context.games.FirstOrDefault(g => g.GameId == entity.GameId);
         if (game != null)
         {
            game.Title = entity.Title;
            game.Resume = entity.Resume;
            game.Genres = entity.Genres;
            _context.SaveChanges();
            return true;
         }
         return false;
      }

      public IEnumerable<Game> GetFavGames(int id)
      {
         return _context.gameUsers.Where(u => u.UserID == id).Select(u => u.Game);
      }

      public void AddGameToFavList(int userId, int gameId)
      {
         _context.gameUsers.Add(new GameUser { GameId = gameId, UserID = userId });
         _context.SaveChanges();
      }
   }
}
