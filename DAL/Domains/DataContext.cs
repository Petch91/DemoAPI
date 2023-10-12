using DAL.Domains.EntitiesConfig;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domains
{
   public class DataContext : DbContext
   {
      public DbSet<Game> games { get; set; }
      public DbSet<User> users { get; set; }
      public DbSet<Genre> genres { get; set; }
      public DbSet<GameGenre> gameGenres { get; set; }
      public DbSet<GameUser> gameUsers { get; set; }
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-T1P11FV;Initial Catalog=GameEntity;Integrated Security=True;");
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new GameConfig());
         modelBuilder.ApplyConfiguration(new GenreConfig());
         modelBuilder.ApplyConfiguration(new UserConfig());
         modelBuilder.ApplyConfiguration(new GameGenreConfig());
         modelBuilder.ApplyConfiguration(new GameUserConfig());
      }
   }
}
