using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ptoject.Models;
using System.Reflection.Emit;

namespace Ptoject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationDbUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                
                new IdentityRole { Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() }
               


                );

            builder.Entity<IdentityRole>().HasData(

            new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7211", Name = "Student", NormalizedName = "STUDENT".ToUpper() }
              );


            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                UserId = "42127fab-3088-4d0a-95e8-722c328429c8"
            });

            builder.Entity<IdentityUserRole<string>>().HasData(

          new IdentityUserRole<string>
          {
              RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
              UserId = "f607027d-079c-4fce-be92-5280a1d25de0"
          });

        }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<AnswerUser> AnswerUser { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<QuestionUser> QuestionUser { get; set; }

     
    }
}