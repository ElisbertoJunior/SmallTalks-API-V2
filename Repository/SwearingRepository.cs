using Microsoft.EntityFrameworkCore;
using Smalltalks.Data;
using Smalltalks.Models;
using Smalltalks.Repository.Interfaces;
using System.Text.RegularExpressions;

namespace Smalltalks.Repository
{
    public class SwearingRepository : ISwearingRepository
    {
        private readonly SmallTalksDBContext _dbCcontext;

        public SwearingRepository(SmallTalksDBContext context) 
        {
            _dbCcontext = context;
        }

        public async Task<SwearingModel> Add(SwearingModel swearing)
        {
            List<SwearingModel> list = await GetAll();

            foreach (var model in list)
            {
                var nameInList = Regex.Replace(model.Name, @"[^\w\s]", "");
                var entryName = Regex.Replace(swearing.Name, @"[^\w\s]", "");

                if (nameInList.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Xinagamento ja existente na base de dados...");
                }
            }

            await _dbCcontext.Swearings.AddAsync(swearing);
            await _dbCcontext.SaveChangesAsync();

            return swearing;
        }

        public async Task<bool> Delete(long id)
        {
            SwearingModel swearingDB = await GetById(id);

            if (swearingDB == null)
            {
                throw new Exception($"Xingamento para ID: {id} nao localizado...");
            }

            _dbCcontext.Swearings.Remove(swearingDB);
            await _dbCcontext.SaveChangesAsync();

            return true;
        }

        public async Task<List<SwearingModel>> GetAll()
        {
            return await _dbCcontext.Swearings.ToListAsync();
        }

        public async Task<SwearingModel> GetById(long id)
        {
            SwearingModel swearing = await _dbCcontext.Swearings.FirstOrDefaultAsync(x => x.Id == id);

            if (swearing == null)
            {
                throw new Exception("Xingamento nao encontrado na base de dados...");
            }

            return swearing;
        }

        public async Task<SwearingModel> Update(SwearingModel swearingModel, long id)
        {
            SwearingModel swearingDB = await GetById(id);

            if (swearingDB == null)
            {
                throw new Exception($"Xingamento para ID: {id} nao localizado...");
            }

            swearingDB.Name = swearingModel.Name;

            _dbCcontext.Swearings.Update(swearingDB);
            await _dbCcontext.SaveChangesAsync();

            return swearingDB;
        }
    }
}
