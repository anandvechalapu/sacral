using Sacral.DataAccess;
using Sacral.DTO;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sacral.Service
{
    public class UserManagementControllerService : IUserManagementControllerRepository
    {
        private readonly IUserManagementControllerRepository _userManagementControllerRepository;

        public UserManagementControllerService(IUserManagementControllerRepository userManagementControllerRepository)
        {
            _userManagementControllerRepository = userManagementControllerRepository;
        }

        public async Task<IEnumerable<UserManagementControllerModel>> GetAllAsync()
        {
            return await _userManagementControllerRepository.GetAllAsync();
        }

        public async Task<UserManagementControllerModel> GetByIdAsync(int id)
        {
            return await _userManagementControllerRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(UserManagementControllerModel user)
        {
            await _userManagementControllerRepository.AddAsync(user);
        }

        public async Task<bool> UpdateAsync(UserManagementControllerModel user)
        {
            return await _userManagementControllerRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userManagementControllerRepository.DeleteAsync(id);
        }
    }
}