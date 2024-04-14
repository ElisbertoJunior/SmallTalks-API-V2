using Smalltalks.Models;

namespace Smalltalks.Repository.Interfaces
{
    public interface ISalutationRepository
    {
        Task<List<SalutationModel>> GetAll();

        Task<SalutationModel> GetById(long id);

        Task<SalutationModel> Add(SalutationModel salutation);

        Task<SalutationModel> Update(SalutationModel salutation, long id);

        Task<bool> Delete(long id);
    }
}
