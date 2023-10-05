using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models
{
   public class GenreForm
   {
      [Required]
      public string Label { get; set; } 
   }
}
