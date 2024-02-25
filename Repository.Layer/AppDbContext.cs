using Core.Layer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }//veri tabanıyla entityi eşledik

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<EBook> EBooks { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BlogCategory> BlogsCategories { get; set; }//bu bizim çoka çok ilişkimizi sağlıycak modelimiz.

        public DbSet<Hiring> Hirings { get; set; }

        public DbSet<OpenToWork> OpenToWorks { get; set; }

        public DbSet<CourseRequest> CourseRequests { get; set; }

        public DbSet<CourseCode> CourseCodes { get; set; }

        

        //Configuration ile eklenen Assemblileri Efcore a bildirdik
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);


        }





    }



}
