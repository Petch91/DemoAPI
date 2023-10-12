using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
   public interface IBaseService<TEntity> where TEntity : class
   {
      TEntity Create(TEntity entity);
      IEnumerable<TEntity> ReadAll();
      TEntity ReadOne(int id);
      bool Update( TEntity entity);
      bool Delete(int id);
   }
}
