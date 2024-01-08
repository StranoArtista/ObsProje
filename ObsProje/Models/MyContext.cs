using ObsProje.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ObsProje.Configurations;

namespace ObsProje.Models
{
    public class MyContext : IdentityDbContext<User,Role,int,IdentityUserClaim<int>,User_Role, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new Class_Configuration());
            builder.ApplyConfiguration(new Exam_Configuration());
            builder.ApplyConfiguration(new Role_Configuration());
            builder.ApplyConfiguration(new Syllabus_Configuration());
            builder.ApplyConfiguration(new User_Class_Configuration());
            builder.ApplyConfiguration(new User_Configuration());
            builder.ApplyConfiguration(new User_Exam_Configuration());
            builder.ApplyConfiguration(new User_Role_Configuration());
         
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Syllabus> Syllabuses  { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Class>  User_Classes { get; set; }
        public DbSet<User_Exam> User_Exams { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }

    }
}