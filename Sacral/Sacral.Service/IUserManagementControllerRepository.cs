using Sacral.DTO;
using Sacral.DataAccess;

namespace Sacral.Service
{
    public interface IUserManagementControllerRepository
    {
        Task<IEnumerable<UserManagementControllerModel>> GetAllAsync();
        Task<UserManagementControllerModel> GetByIdAsync(int id);
        Task AddAsync(UserManagementControllerModel user);
        Task<bool> UpdateAsync(UserManagementControllerModel user);
        Task<bool> DeleteAsync(int id);
    }
}