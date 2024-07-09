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
                new SwearingModel { Id = 3, Name = "Puta" },
                 new SwearingModel { Id = 4, Name = "É foda" },
                new SwearingModel { Id = 5, Name = "E ai" },
                new SwearingModel { Id = 6, Name = "Homossexual" },
                new SwearingModel { Id = 7, Name = "Gay" },
                new SwearingModel { Id = 8, Name = "Caralho" },
                new SwearingModel { Id = 9, Name = "Que merda" },
                new SwearingModel { Id = 11, Name = "Porra" },
                new SwearingModel { Id = 12, Name = "Tudo em ordem?" },
                new SwearingModel { Id = 13, Name = "Filho da puta" },
                new SwearingModel { Id = 14, Name = "Vai tomar no cu" },
                new SwearingModel { Id = 15, Name = "Tomar no cu" },
                new SwearingModel { Id = 16, Name = "Viado" },
                new SwearingModel { Id = 17, Name = "Boceta" },
                new SwearingModel { Id = 18, Name = "Macaco" },
                new SwearingModel { Id = 20, Name = "Macaca" },
                new SwearingModel { Id = 21, Name = "Pau" },
                new SwearingModel { Id = 22, Name = "Pau no cu" },
                new SwearingModel { Id = 23, Name = "Piroca" },
                new SwearingModel { Id = 24, Name = "Corno" },
                new SwearingModel { Id = 25, Name = "Corna" },
                new SwearingModel { Id = 26, Name = "Vagabunda" },
                new SwearingModel { Id = 27, Name = "Vagabundo" },
                new SwearingModel { Id = 28, Name = "Toma no cu" },
                new SwearingModel { Id = 29, Name = "Filha da puta" },
                new SwearingModel { Id = 30, Name = "Foda" }
            );

            modelBuilder.Entity<SalutationModel>().HasData(
                new SalutationModel { Id = 1, Name = "Bom dia" },
                new SalutationModel { Id = 2, Name = "Boa tarde" },
                new SalutationModel { Id = 3, Name = "Boa noite" },
                new SalutationModel { Id = 4, Name = "Oi" },
                new SalutationModel { Id = 5, Name = "Tudo bem?" },
                new SalutationModel { Id = 6, Name = "Olá" },
                new SalutationModel { Id = 7, Name = "Como vai?" },
                new SalutationModel { Id = 8, Name = "E ai" },
                new SalutationModel { Id = 9, Name = "Beleza?" },
                new SalutationModel { Id = 10, Name = "Bom dia!" },
                new SalutationModel { Id = 11, Name = "Boa tarde!" },
                new SalutationModel { Id = 12, Name = "Boa noite!" },
                new SalutationModel { Id = 13, Name = "Como você está?" },
                new SalutationModel { Id = 14, Name = "Como você está se sentindo hoje?" },
                new SalutationModel { Id = 15, Name = "Tudo em ordem?" },
                new SalutationModel { Id = 16, Name = "Que tal" },
                new SalutationModel { Id = 17, Name = "Como estão as coisas?" },
                new SalutationModel { Id = 18, Name = "Beleza pura?" },
                new SalutationModel { Id = 19, Name = "Bom te ver!" },
                new SalutationModel { Id = 20, Name = "Como tem passado?" },
                new SalutationModel { Id = 21, Name = "De boa?" },
                new SalutationModel { Id = 22, Name = "Que prazer te encontrar!" },
                new SalutationModel { Id = 23, Name = "Tudo joia?" }
            );

            modelBuilder.Entity<ToThankModel>().HasData(
                new ToThankModel { Id = 1, Name = "Obrigado" },
                new ToThankModel { Id = 2, Name = "Agradecido" },
                new ToThankModel { Id = 3, Name = "Agradeço" },
                new ToThankModel { Id = 4, Name = "Obrigado" },
                new ToThankModel { Id = 5, Name = "Grato" },
                new ToThankModel { Id = 6, Name = "Agradeço" },
                new ToThankModel { Id = 7, Name = "Valeu" },
                new ToThankModel { Id = 8, Name = "Muito obrigado" },
                new ToThankModel { Id = 9, Name = "Obrigadão" },
                new ToThankModel { Id = 10, Name = "Obrigadíssimo" },
                new ToThankModel { Id = 11, Name = "Agradecimento" },
                new ToThankModel { Id = 13, Name = "Gratidão" },
                new ToThankModel { Id = 14, Name = "Obrigadinho" },
                new ToThankModel { Id = 15, Name = "Muito obrigada" },
                new ToThankModel { Id = 16, Name = "Agradecendo" },
                new ToThankModel { Id = 17, Name = "Agradecidamente" },
                new ToThankModel { Id = 18, Name = "Agradeço muito" },
                new ToThankModel { Id = 19, Name = "Fico grato" },
                new ToThankModel { Id = 20, Name = "Agradecemos" },
                new ToThankModel { Id = 21, Name = "Muito agradecido" },
                new ToThankModel { Id = 22, Name = "Obrigada" },
                new ToThankModel { Id = 23, Name = "Agradecida" },
                new ToThankModel { Id = 24, Name = "Grata" },
                new ToThankModel { Id = 25, Name = "Obrigadona" },
                new ToThankModel { Id = 26, Name = "Fico grata" },
                new ToThankModel { Id = 27, Name = "Muito agradecida" }

            );
        }
    }


}
