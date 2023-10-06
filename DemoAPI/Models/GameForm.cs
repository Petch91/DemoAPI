using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models
{
   public class GameForm
   {
      [Required]
      public string Title { get; set; }
      [Required]
      public DateTime DateDeSortie { get; set; }
      [Required]
      [Range(1, int.MaxValue)]
      public int IdGenre { get; set; }
      public string? Resume { get; set; }
   }
}
