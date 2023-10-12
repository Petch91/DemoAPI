using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domains.EntitiesConfig
{
   public class GameUserConfig : IEntityTypeConfiguration<GameUser>
   {
      public void Configure(EntityTypeBuilder<GameUser> builder)
      {
         builder.HasKey(k => new { k.UserID, k.GameId });

         builder.HasOne(x => x.User).WithMany(u => u.Favoris).HasForeignKey(x => x.UserID);

         builder.HasOne(x => x.Game).WithMany(g => g.ByUsers).HasForeignKey(x => x.GameId);

      }
   }
}
