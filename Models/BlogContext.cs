using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Gerardo_BLOG.Models
{
    ///
    ///Summary :This context initialize the tables Category and Post, Here load the default data to category table
    ///
    public class BlogContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        ///Load Default data;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var tmpList = new List<Category> {
                            new Category{  Id=1, Title = "News"} ,
                            new Category{  Id=2, Title = "Food"} ,
                            new Category{  Id=3, Title = "Travel"} ,
                            new Category{  Id=4, Title = "Work"} ,
            };
            modelBuilder.Entity<Category>().HasData(tmpList);
        }

        
       

    }
}