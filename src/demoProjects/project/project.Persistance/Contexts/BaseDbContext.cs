using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Persistance.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(x =>
            {
                x.ToTable("Languages").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p=>p.Name).HasColumnName("Name");
            });

            //Language[] languageEntitySeeds = { new(1, "C#") };
            //modelBuilder.Entity<Language>().HasData(languageEntitySeeds);
        }
    }
}
