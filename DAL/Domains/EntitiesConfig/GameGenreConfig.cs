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
   public class GameGenreConfig : IEntityTypeConfiguration<GameGenre>
   {
      public void Configure(EntityTypeBuilder<GameGenre> builder)
      {
         builder.HasKey(k => new { k.GameId, k.GenreId });

         builder.HasOne(x => x.Genre).WithMany(g => g.ByGenres).HasForeignKey(g => g.GenreId).OnDelete(DeleteBehavior.NoAction);
         builder.HasOne(x => x.Game).WithMany(g => g.Genres).HasForeignKey(g => g.GameId).OnDelete(DeleteBehavior.NoAction);

         builder.HasData(
                           new GameGenre { GameId = 1 , GenreId = 2},
                           new GameGenre { GameId = 2, GenreId = 2 },
                           new GameGenre { GameId = 2, GenreId = 1 },
                           new GameGenre { GameId = 3, GenreId = 3 },
                           new GameGenre { GameId = 4, GenreId = 1 }
                        );
      }
   }
}
