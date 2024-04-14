using Smalltalks.Models;

namespace Smalltalks.Repository.Interfaces
{
    public interface IToThankRepository
    {
        Task<List<ToThankModel>> GetAll();

        Task<ToThankModel> GetById(long id);

        Task<ToThankModel> Add(ToThankModel toThankModel);

        Task<ToThankModel> Update(ToThankModel toThankModel, long id);

        Task<bool> Delete(long id);
    }
}
