using DAL.Entities.Enums;

namespace DAL.Entities
{
   public class User
   {
      public int UserId { get; set; }
      public string UserName { get; set; }
      public string Email { get; set; }
      public string PasswordHash { get; set; }
      public int RoleId { get; set; }
      public List<GameUser> Favoris {  get; set; }

   }


}
