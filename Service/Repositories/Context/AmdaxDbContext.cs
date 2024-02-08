using Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Service.Repositories.Context
{
    internal class AmdaxDbContext : DbContext
    {
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<ApplicantReview> ApplicantReview { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServerConString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureApplicantModelBinding(modelBuilder);
            ConfigureApplicantReivewModelBinding(modelBuilder);
        }

        private void ConfigureApplicantModelBinding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
            .HasKey(o => o.ApplicantId);

            modelBuilder.Entity<Applicant>()
                .HasOne(o => o.ApplicantReview)
                .WithOne(i => i.Applicant)
                .HasForeignKey<ApplicantReview>(i => i.ApplicantId);
        }

        private void ConfigureApplicantReivewModelBinding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantReview>()
            .HasKey(i => i.ApplicantReviewId);
        }
    }
}
