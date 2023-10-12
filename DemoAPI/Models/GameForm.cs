
using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models
{
   public class GameForm
   {
      [Required]
      public string Title { get; set; }
      [Required]
      [Range(1, int.MaxValue)]
      public int GenreId { get; set; }
      public string? Resume { get; set; }
   }
}
