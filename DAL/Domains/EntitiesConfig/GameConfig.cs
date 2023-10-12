using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domains.EntitiesConfig
{
   public class GameConfig : IEntityTypeConfiguration<Game>
   {
      public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Game> builder)
      {
         builder.Property(p => p.Title).HasColumnType("VARCHAR(100)").IsRequired();

         builder.HasData(  new Game { GameId = 1, Title = "FF9", Resume = "Best Game" },
                           new Game { GameId = 2, Title = "FF16", Resume = "manque un truc" },
                           new Game { GameId = 3, Title = "Uncharted", Resume = "Best TPS Game" },
                           new Game { GameId = 4, Title = "God Of War", Resume = "Best Action Game" }
                        );
      }
   }
}
