using Smalltalks.Models;
using Smalltalks.Repository.Interfaces;
using System.Text.RegularExpressions;

namespace Smalltalks.Services
{
    public class SwearingService : ISwearingRepository
    {

        List<SwearingModel> swearings = new List<SwearingModel>
            {
                new SwearingModel { Id =1, Name = "Bosta"},
                new SwearingModel { Id =2, Name = "Cassete"},
                new SwearingModel { Id =3, Name = "Foda"},
                new SwearingModel { Id =4, Name = "É foda"},
                new SwearingModel { Id =5, Name = "E ai"},
                new SwearingModel { Id =6, Name = "Homossexual"},
                new SwearingModel { Id =7, Name = "Gay"},
                new SwearingModel { Id =8, Name = "Caralho"},
                new SwearingModel { Id =9, Name = "Que merda"},
                new SwearingModel { Id =11, Name = "Porra"},
                new SwearingModel { Id =12, Name = "Tudo em ordem?"},
                new SwearingModel { Id =13, Name = "Filho da puta"},
                new SwearingModel { Id =14, Name = "Vai tomar no cu"},
                new SwearingModel { Id =15, Name = "Tomar no cu"},
                new SwearingModel { Id =16, Name = "Viado"},
                new SwearingModel { Id =17, Name = "Boceta"},
                new SwearingModel { Id =18, Name = "Macaco"},
                new SwearingModel { Id =20, Name = "Macaca"},
                new SwearingModel { Id =21, Name = "Pau"},
                new SwearingModel { Id =22, Name = "Pau no cu"},
                new SwearingModel { Id =23, Name = "Piroca"},
                new SwearingModel { Id =24, Name = "Corno"},
                new SwearingModel { Id =25, Name = "Corna"},
                new SwearingModel { Id =26, Name = "Vagabunda"},
                new SwearingModel { Id =27, Name = "Vagabundo"},
                new SwearingModel { Id =28, Name = "Toma no cu"},
                new SwearingModel { Id =29, Name = "Filha da puta"}

          };

        public Task<SwearingModel> Add(SwearingModel swearing)
        {
            List<SwearingModel> list = swearings;
            long newId = list.LastOrDefault()?.Id + 1 ?? 1;

            foreach (var model in list)
            {
                var nameInList = Regex.Replace(model.Name, @"[^\w\s]", "");
                var entryName = Regex.Replace(swearing.Name, @"[^\w\s]", "");

                if (nameInList.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Saudacao ja existente na base de dados...");
                }
            }

            // Criar um novo objeto SalutationModel com os dados fornecidos
            SwearingModel newSwearing = new SwearingModel
            {
                Id = newId,
                Name = swearing.Name
            };

            // Adicionar o novo objeto à lista
            swearings.Add(newSwearing);
            return Task.FromResult(newSwearing);
        }

        public Task<bool> Delete(long id)
        {
            List<SwearingModel> list = swearings;
            SwearingModel swearingDB = list.FirstOrDefault(s => s.Id == id);

            if (swearingDB == null)
            {
                throw new Exception($"Saudacao para ID: {id} nao localizado...");
            }

            list.Remove(swearingDB);
            swearings = list;

            return Task.FromResult(true);
        }

        public Task<List<SwearingModel>> GetAll()
        {
            return Task.FromResult(swearings);
        }

        public Task<SwearingModel> GetById(long id)
        {
            SwearingModel swearing = swearings.FirstOrDefault(x => x.Id == id);

            if (swearing == null)
            {
                throw new Exception("Ximgamento nao encontrado na base de dados...");
            }

            return Task.FromResult(swearing);
        }

        public Task<SwearingModel> Update(SwearingModel swearingModel, long id)
        {
            SwearingModel swearingDB = swearings.FirstOrDefault(x => x.Id == id);

            if (swearingDB == null)
            {
                throw new Exception($"Xingamento para o ID: {id} nao localizado...");
            }

            swearingDB.Name = swearingModel.Name;


            return Task.FromResult(swearingDB);
        }
    }
}
