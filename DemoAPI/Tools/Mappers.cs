﻿using DAL.Models;
using DemoAPI.Models;
using DemoASP.Models.ViewModel;
using System.Runtime.CompilerServices;

namespace DemoAPI.Tools
{
   public static class Mappers
   {
      public static Game ToGame(this GameForm game)
      {
         return new Game { Title = game.Title, DateDeSortie = DateTime.Now, Genres = new Genre { Id = game.IdGenre}, Resume = game.Resume };
      }

      public static GameForm ToGameForm(this Game game)
      {
         return new GameForm { Title = game.Title, IdGenre = game.Genres.Id, Resume = game.Resume };
      }

      public static Genre ToGenre(this GenreForm genre) 
      {
         return new Genre { Label = genre.Label };
      }
      public static UserView ToUserView(this User user)
      {
         return new UserView { Id = user.Id, Role = user.Role, UserName = user.UserName };
      }
   }
}
