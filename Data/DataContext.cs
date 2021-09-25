using Microsoft.EntityFrameworkCore;
// using ToDoWeb.Models;
using ToDoServer.Models;

namespace ToDoServer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}