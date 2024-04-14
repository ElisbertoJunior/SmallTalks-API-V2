using Microsoft.EntityFrameworkCore;
using Smalltalks.Data;
using Smalltalks.Models;
using Smalltalks.Repository.Interfaces;
using System.Text.RegularExpressions;

namespace Smalltalks.Repository
{
    public class SalutationRepository : ISalutationRepository
    {
        private readonly SmallTalksDBContext _dbCcontext;

        public SalutationRepository(SmallTalksDBContext dbContext) 
        {
            _dbCcontext = dbContext;
        }

        public async Task<SalutationModel> Add(SalutationModel salutation)
        {
            List<SalutationModel> list = await GetAll();

            foreach (var model in list)
            {
                var nameInList = Regex.Replace(model.Name, @"[^\w\s]", "");
                var entryName = Regex.Replace(salutation.Name, @"[^\w\s]", "");

                if (nameInList.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Saudacao ja existente na base de dados...");
                }
            }

            await _dbCcontext.Salutations.AddAsync(salutation);
            await _dbCcontext.SaveChangesAsync();

            return salutation;
        }

        public async Task<bool> Delete(long id)
        {
            SalutationModel salutationDB = await GetById(id);

            if (salutationDB == null)
            {
                throw new Exception($"Xingamento para ID: {id} nao localizado...");
            }

            _dbCcontext.Salutations.Remove(salutationDB);
            await _dbCcontext.SaveChangesAsync();

            return true;
        }

        public async Task<List<SalutationModel>> GetAll()
        {
            return await _dbCcontext.Salutations.ToListAsync();
        }

        public async Task<SalutationModel> GetById(long id)
        {
            SalutationModel salutation = await _dbCcontext.Salutations.FirstOrDefaultAsync(x => x.Id == id);

            if (salutation == null)
            {
                throw new Exception("Saudacao nao encontrado na base de dados...");
            }

            return salutation;
        }

        public async Task<SalutationModel> Update(SalutationModel salutationModel, long id)
        {
            SalutationModel salutationDB = await GetById(id);

            if (salutationDB == null)
            {
                throw new Exception($"Saudacao para o ID: {id} nao localizado...");
            }

            salutationDB.Name = salutationModel.Name;

            _dbCcontext.Salutations.Update(salutationDB);
            await _dbCcontext.SaveChangesAsync();

            return salutationDB;
        }
    }
}
