using Smalltalks.Models;
using Smalltalks.Repository.Interfaces;
using System.Text.RegularExpressions;

namespace Smalltalks.Services
{
    public class SalutationService : ISalutationRepository
    {

        List<SalutationModel> salutations = new List<SalutationModel>
            {
                new SalutationModel { Id =1, Name = "Oi"},
                new SalutationModel { Id =2, Name = "Tudo bem?"},
                new SalutationModel { Id =3, Name = "Olá"},
                new SalutationModel { Id =4, Name = "Como vai?"},
                new SalutationModel { Id =5, Name = "E ai"},
                new SalutationModel { Id =6, Name = "Beleza?"},
                new SalutationModel { Id =7, Name = "Bom dia!"},
                new SalutationModel { Id =8, Name = "Boa tarde!"},
                new SalutationModel { Id =9, Name = "Boa noite!"},
                new SalutationModel { Id =10, Name = "Como você está?"},
                new SalutationModel { Id =11, Name = "Como você está se sentindo hoje?"},
                new SalutationModel { Id =12, Name = "Tudo em ordem?"},
                new SalutationModel { Id =13, Name = "Que tal"},
                new SalutationModel { Id =14, Name = "Como estão as coisas?"},
                new SalutationModel { Id =15, Name = "Beleza pura?"},
                new SalutationModel { Id =16, Name = "Bom te ver!"},
                new SalutationModel { Id =17, Name = "Como tem passado?"},
                new SalutationModel { Id =18, Name = "De boa?"},
                new SalutationModel { Id =19, Name = "Que prazer te encontrar!"},
                new SalutationModel { Id =20, Name = "Tudo joia?"}

          };
        public Task<SalutationModel> Add(SalutationModel salutation)
        {
            List<SalutationModel> list = salutations;
            long newId = salutations.LastOrDefault()?.Id + 1 ?? 1;

            foreach (var model in list)
            {
                var nameInList = Regex.Replace(model.Name, @"[^\w\s]", "");
                var entryName = Regex.Replace(salutation.Name, @"[^\w\s]", "");

                if (nameInList.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Saudacao ja existente na base de dados...");
                }
            }

            // Criar um novo objeto SalutationModel com os dados fornecidos
            SalutationModel newSalutation = new SalutationModel
            {
                Id = newId,
                Name = salutation.Name
            };

            // Adicionar o novo objeto à lista
            salutations.Add(newSalutation);
            return Task.FromResult(newSalutation);
        }

        public Task<bool> Delete(long id)
        {
            List<SalutationModel> list = salutations;
            SalutationModel salutationDB = list.FirstOrDefault(s => s.Id == id);

            if (salutationDB == null)
            {
                throw new Exception($"Saudacao para ID: {id} nao localizado...");
            }

            list.Remove(salutationDB);
            salutations = list;

            return Task.FromResult(true);
        }

        public Task<List<SalutationModel>> GetAll()
        {
            return Task.FromResult(salutations);
        }

        public Task<SalutationModel> GetById(long id)
        {
            SalutationModel salutation = salutations.FirstOrDefault(x => x.Id == id);

            if (salutation == null)
            {
                throw new Exception("Saudacao nao encontrado na base de dados...");
            }

            return Task.FromResult(salutation);
        }

        public Task<SalutationModel> Update(SalutationModel salutation, long id)
        {
            
                SalutationModel salutationDB = salutations.FirstOrDefault(x => x.Id == id);

                if (salutationDB == null)
                {
                    throw new Exception($"Saudacao para o ID: {id} nao localizado...");
                }

                salutationDB.Name = salutation.Name;


                return Task.FromResult(salutationDB);
            
        }
    }
}
