using Microsoft.EntityFrameworkCore;
using Smalltalks.Data.Map;
using Smalltalks.Models;

namespace Smalltalks.Data
{
    public class SmallTalksDBContext : DbContext
    {
        public SmallTalksDBContext(DbContextOptions<SmallTalksDBContext> options) : base(options) 
        {
        }

        public DbSet<SwearingModel> Swearings { get; set; }

        public DbSet<SalutationModel> Salutations { get; set;}

        public DbSet<ToThankModel> ToThanks { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SwearingMap());
            modelBuilder.ApplyConfiguration(new SalutationMap());
            modelBuilder.ApplyConfiguration(new ToThankMap());

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SwearingModel>().HasData(
                new SwearingModel { Id = 1, Name = "Caralho" },
                new SwearingModel { Id = 2, Name = "Cacete" },
                new SwearingModel { Id = 3, Name = "Puta" }
            );

            modelBuilder.Entity<SalutationModel>().HasData(
                new SalutationModel { Id = 1, Name = "Bom dia" },
                new SalutationModel { Id = 2, Name = "Boa tarde" },
                new SalutationModel { Id = 3, Name = "Boa noite" }
            );

            modelBuilder.Entity<ToThankModel>().HasData(
                new ToThankModel { Id = 1, Name = "Obrigado" },
                new ToThankModel { Id = 2, Name = "Agradecido" },
                new ToThankModel { Id = 3, Name = "Agradeço" }
            );
        }
    }


}
