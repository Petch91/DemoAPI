using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models
{
   public class GameForm
   {
      [Required]
      public string Title { get; set; }
      public DateTime DateDeSortie { get; set; }
      public int IdGenre { get; set; }
      public string? Resume { get; set; }
   }
}
