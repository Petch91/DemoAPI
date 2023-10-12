using DAL.Entities.Enums;

namespace DemoASP.Models.ViewModel
{
   public class UserView
   {
      public int UserId { get; set; }
      public string UserName { get; set; }
      public Role Role { get; set; }
   }
}
