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
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<GithubProfile> GithubProfiles { get; set; }

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
                x.Property(p => p.Name).HasColumnName("Name");
                x.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(x =>
            {
                x.ToTable("Technologies").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.LanguageId).HasColumnName("LanguageId");
                x.Property(p => p.Name).HasColumnName("Name");
                x.HasOne(p => p.Language);
            });

            modelBuilder.Entity<GithubProfile>(x =>
            {
                x.ToTable("GithubProfiles").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.UserId).HasColumnName("UserId");
                x.Property(p => p.RepositoryName).HasColumnName("RepositoryName");
                x.Property(p => p.Url).HasColumnName("Url");
            });

            //Language[] languageEntitySeeds = { new(1, "C#") };
            //modelBuilder.Entity<Language>().HasData(languageEntitySeeds);

            //Technology[] technolgyEntitySeeds = { new(1, 1, "ASP.Net") };
            //modelBuilder.Entity<Technology>().HasData(technolgyEntitySeeds);

            //GithubProfile[] githubEntitySeeds = { new(1, 1, "test", "test.com") };
            //modelBuilder.Entity<GithubProfile>().HasData(githubEntitySeeds);
        }
    }
}
