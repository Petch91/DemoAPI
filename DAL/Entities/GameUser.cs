using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class GameUser
   {
      public int GameId { get; set; }
      public Game Game { get; set; }
      public int UserID { get; set; }
      public User User { get; set; }
   }
}
