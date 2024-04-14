using Microsoft.EntityFrameworkCore;
using Smalltalks.Data;
using Smalltalks.Models;
using Smalltalks.Repository.Interfaces;
using System.Text.RegularExpressions;

namespace Smalltalks.Repository
{
    public class ToThankRepository : IToThankRepository
    {
        private readonly SmallTalksDBContext _dbContext;
        public ToThankRepository(SmallTalksDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<ToThankModel> Add(ToThankModel toThankModel)
        {
            List<ToThankModel> list = await GetAll();

            foreach (var model in list)
            {
                var nameInList = Regex.Replace(model.Name, @"[^\w\s]", "");
                var entryName = Regex.Replace(toThankModel.Name, @"[^\w\s]", "");

                if (nameInList.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Xinagamento ja existente na base de dados...");
                }
            }

            await _dbContext.ToThanks.AddAsync(toThankModel);
            await _dbContext.SaveChangesAsync();

            return toThankModel;
        }

        public async Task<bool> Delete(long id)
        {
            ToThankModel toThankDB = await GetById(id);

            if (toThankDB == null)
            {
                throw new Exception($"Agradecimento para ID: {id} nao localizado...");
            }

            _dbContext.ToThanks.Remove(toThankDB);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<ToThankModel>> GetAll()
        {
            return await _dbContext.ToThanks.ToListAsync();
        }

        public async Task<ToThankModel> GetById(long id)
        {
            ToThankModel toThank = await _dbContext.ToThanks.FirstOrDefaultAsync(x => x.Id == id);

            if (toThank == null)
            {
                throw new Exception("Agradecimento nao encontrado na base de dados...");
            }

            return toThank;
        }

        public async Task<ToThankModel> Update(ToThankModel toThankModel, long id)
        {
            ToThankModel toThankDB = await GetById(id);

            if (toThankDB == null)
            {
                throw new Exception($"Xingamento para ID: {id} nao localizado...");
            }

            toThankDB.Name = toThankModel.Name;

            _dbContext.ToThanks.Update(toThankDB);
            await _dbContext.SaveChangesAsync();

            return toThankDB;
        }
    }
}
