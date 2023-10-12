using DAL.Domains;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
   public class GenreService : IGenreService
   {
      private readonly DataContext _context;

      public GenreService(DataContext dataContext)
      {
         _context = dataContext;
      }
      public Genre Create(Genre entity)
      {
         _context.genres.Add(entity);
         _context.SaveChanges();
         return _context.genres.OrderBy(x => x.GenreId).Last();
      }

      public bool Delete(int id)
      {
         Genre genre = _context.genres.FirstOrDefault(g => g.GenreId == id);
         if (genre != null)
         {
            _context.genres.Remove(genre);
            _context.SaveChanges();
            return true;
         }
         return false;
      }

      public IEnumerable<Genre> ReadAll()
      {
         return _context.genres;
      }

      public Genre ReadOne(int id)
      {
         throw new NotImplementedException();
      }

      public bool Update(Genre entity)
      {
         throw new NotImplementedException();
      }
   }
}
