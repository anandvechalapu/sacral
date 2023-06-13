using MongoDB.Driver;
using Sacral.DTO;

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