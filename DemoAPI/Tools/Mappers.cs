using DAL.Entities.Enums;
using DAL.Entities;
using DemoAPI.Models;
using DemoASP.Models.ViewModel;
using System.Runtime.CompilerServices;

namespace DemoAPI.Tools
{
   public static class Mappers
   {
      public static Game ToGame(this GameForm game)
      {
         return new Game { Title = game.Title, GenreId = game.GenreId, Resume = game.Resume };
      }

      public static GameForm ToGameForm(this Game game)
      {
         return new GameForm { Title = game.Title, Resume = game.Resume };
      }

      public static Genre ToGenre(this GenreForm genre) 
      {
         return new Genre { Label = genre.Label };
      }
      public static UserView ToUserView(this DAL.Entities.User user)
      {
         return new UserView { UserId = user.UserId, Role = (Role)user.RoleId, UserName = user.UserName };
      }
      public static DemoAPI.Models.User ToAPI(this DAL.Entities.User user)
      {
         return new DemoAPI.Models.User { Email = user.Email, UserId = user.UserId, UserName = user.UserName, RoleId = user.RoleId };
      }
   }
}
