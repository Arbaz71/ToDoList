using Microsoft.EntityFrameworkCore;
using System.Xml;
using To_Do_List.Models;
using ToDoList.Models;

namespace To_Do_List.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<RegisterUser> RegisterUsers { get; set; }
        public DbSet<LoginUser>LoginUsers { get; set; }
        public DbSet<ToDoItem> ToDoItemList { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginUser>()
                .HasNoKey();

            // Other configurations...
        }
    }

    
}
