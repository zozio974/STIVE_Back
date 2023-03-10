using Microsoft.EntityFrameworkCore;
using ProjetCUBES.Model;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProjetCUBES.Helpers
{
    public class Class
    {
        public class Apply : DbContext
        {
            public DbSet<Article> Articles { get; set; }
            public DbSet<Family> Familys { get; set; }
            public DbSet<Supplier> Suppliers { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Job> Jobs { get; set; }
            public DbSet<Command> Commands { get; set; }
            public DbSet<LineCommand> LineCommands { get; set; }
            public DbSet<StatusCommand> StatusCommands { get; set; }
            public DbSet<Auto> Autos { get; set; }








            public Apply() { }

            public Apply(DbContextOptions<Apply> options)
                : base(options) { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
            {
                if (!optionBuilder.IsConfigured)
                {
                    optionBuilder.UseMySql("server=localhost;user=root;password=mysql;database=basetest", ServerVersion.Parse("8.0.31-mysql"));
                }
            }
        }
    }
}
