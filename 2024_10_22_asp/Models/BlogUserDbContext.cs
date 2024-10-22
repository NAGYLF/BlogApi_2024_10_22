using Microsoft.EntityFrameworkCore;

namespace _2024_10_22_asp.Models
{
    public class BlogUserDbContext :DbContext
    {
       
        public BlogUserDbContext() { }

        public BlogUserDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "server=localhost; database=BlogUsers; user=root; password=";

                optionsBuilder.UseMySQL(conn);
            }
        }

        public DbSet<BlogUser> NewBlogUser { get; set; } = null!;
    }
}
