using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Genre
   {
      public int GenreId { get; set; }
      public string Label { get; set; }
      public List<GameGenre> ByGenres { get; set;  }
   }
}
