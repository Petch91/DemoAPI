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
   public class GenreConfig : IEntityTypeConfiguration<Genre>
   {
      public void Configure(EntityTypeBuilder<Genre> builder)
      {
         builder.Property( p => p.Label).HasColumnType("VARCHAR(100)").IsRequired();

         builder.HasData(
                           new Genre { GenreId = 1, Label = "Action"},
                           new Genre { GenreId = 2, Label = "RPG" },
                           new Genre { GenreId = 3, Label = "TPS" }
                        );
      }
   }
}
