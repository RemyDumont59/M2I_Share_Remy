using Exercice02.Data;
using Exercice02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Exercice02.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Todo> Todo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int _lastIndex = 0;
            var tasks = new List<Todo>()
            {
                new Todo(){ Id = ++_lastIndex, Name = "Rangement", Description = "Ranger le Salon"},
                new Todo(){ Id = ++_lastIndex, Name = "Promenade", Description = "Promener Loukie"},
            };

            modelBuilder.Entity<Todo>().HasData(tasks);
        }

    }
}

