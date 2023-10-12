using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
   public class Game
   {
      public int GameId { get; set; }
      public string Title { get; set; }
      public string? Resume { get; set; }
      [NotMapped]
      public int GenreId { get; set; }
      public List<GameGenre> Genres { get; set; }
      public List<GameUser> ByUsers { get; set; }
   }
}
