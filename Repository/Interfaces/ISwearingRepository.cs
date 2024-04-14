using Smalltalks.Models;

namespace Smalltalks.Repository.Interfaces
{
    public interface ISwearingRepository
    {
        Task<List<SwearingModel>> GetAll();

        Task<SwearingModel> GetById(long id);

        Task<SwearingModel> Add(SwearingModel swearing);

        Task<SwearingModel> Update(SwearingModel swearingModel, long id);

        Task<bool> Delete(long id);
    }
}
