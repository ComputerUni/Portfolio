using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Entities;

namespace Portfolio.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-213H3J8\\SQLEXPRESS;Database=PortfolioDb;Integrated Security=True;TrustServerCertificate=True;");
        }

        //pluralize-cogullastirma
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TechStack> TechStacks { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ProjectTechStack> ProjectTechStacks { get; set; }

    }
}
