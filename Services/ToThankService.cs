using Smalltalks.Models;
using Smalltalks.Repository.Interfaces;
using System.Text.RegularExpressions;

namespace Smalltalks.Services
{
    public class ToThankService : IToThankRepository
    {

        List<ToThankModel> toThanks = new List<ToThankModel>
            {
                new ToThankModel { Id =1, Name = "Obrigado"},
                new ToThankModel { Id =2, Name = "Agradecido"},
                new ToThankModel { Id =3, Name = "Grato"},
                new ToThankModel { Id =4, Name = "Agradeço"},
                new ToThankModel { Id =5, Name = "Valeu"},
                new ToThankModel { Id =6, Name = "Muito obrigado"},
                new ToThankModel { Id =7, Name = "Obrigadão"},
                new ToThankModel { Id =8, Name = "Obrigadíssimo"},
                new ToThankModel { Id =9, Name = "Agradecimento"},
                new ToThankModel { Id =10, Name = "Gratidão"},
                new ToThankModel { Id =11, Name = "Obrigadinho"},
                new ToThankModel { Id =12, Name = "Muito obrigada"},
                new ToThankModel { Id =13, Name = "Agradecendo"},
                new ToThankModel { Id =14, Name = "Agradecidamente"},
                new ToThankModel { Id =15, Name = "Agradeço muito"},
                new ToThankModel { Id =16, Name = "Fico grato"},
                new ToThankModel { Id =17, Name = "Agradecemos"},
                new ToThankModel { Id =18, Name = "Muito agradecido"},
                new ToThankModel { Id =19, Name = "Obrigada"},
                new ToThankModel { Id =20, Name = "Agradecida"},
                new ToThankModel { Id =21, Name = "Grata"},
                new ToThankModel { Id =22, Name = "Obrigadona"},
                new ToThankModel { Id =23, Name = "Fico grata"},
                new ToThankModel { Id =24, Name = "Muito agradecida"}
                

          };

        public Task<ToThankModel> Add(ToThankModel toThankModel)
        {
            List<ToThankModel> list = toThanks;
            long newId = list.LastOrDefault()?.Id + 1 ?? 1;

            foreach (var model in list)
            {
                var nameInList = Regex.Replace(model.Name, @"[^\w\s]", "");
                var entryName = Regex.Replace(toThankModel.Name, @"[^\w\s]", "");

                if (nameInList.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Saudacao ja existente na base de dados...");
                }
            }

            // Criar um novo objeto SalutationModel com os dados fornecidos
            ToThankModel newToThank = new ToThankModel
            {
                Id = newId,
                Name = toThankModel.Name
            };

            // Adicionar o novo objeto à lista
            toThanks.Add(newToThank);
            return Task.FromResult(newToThank);
        }

        public Task<bool> Delete(long id)
        {
            List<ToThankModel> list = toThanks;
            ToThankModel toThankDB = list.FirstOrDefault(s => s.Id == id);

            if (toThankDB == null)
            {
                throw new Exception($"Agradecimento para ID: {id} nao localizado...");
            }

            list.Remove(toThankDB);
            toThanks = list;

            return Task.FromResult(true);
        }

        public Task<List<ToThankModel>> GetAll()
        {
            return Task.FromResult(toThanks);
        }

        public Task<ToThankModel> GetById(long id)
        {
            ToThankModel toThank = toThanks.FirstOrDefault(x => x.Id == id);

            if (toThank == null)
            {
                throw new Exception("Agradecimento nao encontrado na base de dados...");
            }

            return Task.FromResult(toThank);
        }

        public Task<ToThankModel> Update(ToThankModel toThankModel, long id)
        {
            ToThankModel toThankDB = toThanks.FirstOrDefault(x => x.Id == id);

            if (toThankDB == null)
            {
                throw new Exception($"Xingamento para o ID: {id} nao localizado...");
            }

            toThankDB.Name = toThankModel.Name;


            return Task.FromResult(toThankDB);
        }
    }
}
