using System.ComponentModel.DataAnnotations;

namespace DemoASP.Models.ViewModel
{
   public class UserRegisterForm
   {
      [Required]
      [MinLength(3, ErrorMessage = "Taille minimale : 3 Caratères")]
      public string Username { get; set; }
      [Required]
      [EmailAddress]
      public string Email { get; set; }
      [Required]
      [DataType(DataType.Password)]
      [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")]
      public string Password { get; set; }

   }
}
