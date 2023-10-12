using BCrypt.Net;
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
   public class UserConfig : IEntityTypeConfiguration<User>
   {
      public void Configure(EntityTypeBuilder<User> builder)
      {
         builder.Property(p => p.Email).HasColumnType("VARCHAR(100)").IsRequired();
         builder.Property(p => p.UserName).HasColumnType("VARCHAR(100)").IsRequired();
         builder.Property(p => p.PasswordHash).IsRequired();
         builder.Property(p => p.RoleId).IsRequired().HasDefaultValue(1);

         builder.HasData(
                           new User
                           {
                              UserId = 1,
                              UserName = "Admin",
                              Email = "admin@gmail.com",
                              PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pouyette91"),
                              RoleId = 3
                           },
                           new User
                           {
                              UserId = 2,
                              UserName = "Petch",
                              Email = "petch@gmail.com",
                              PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pouyette91")
                           }
                        );

      }
   }
}
