using Microsoft.EntityFrameworkCore;
// using ToDoWeb.Models;
using ToDoServer.Models;

namespace ToDoServer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

        }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Category { get; set; }
    }


}