using Sacral.DataAccess;
using Sacral.DTO;

namespace Sacral.Service
{
    public interface ILogoutService
    {
        Task<bool> LogoutAsync(int userId);
    }

    public class LogoutServiceImpl : ILogoutService
    {
        private readonly ICalculationService _calculationService;
        private readonly IUserDataAccess _userDataAccess;

        public LogoutServiceImpl(ICalculationService calculationService, IUserDataAccess userDataAccess)
        {
            _calculationService = calculationService;
            _userDataAccess = userDataAccess;
        }

        public async Task<bool> LogoutAsync(int userId)
        {
            try
            {
                // Get the user information
                var user = await _userDataAccess.GetUserAsync(userId);

                // Calculate the user logout time
                int logoutTime = _calculationService.Subtract(DateTime.Now.Second, user.LastLoginTime.Second);
                
                // Update the user logout time
                user.LogoutTime = logoutTime;
                await _userDataAccess.UpdateUserAsync(user);

                // Return true
                return true;
            }
            catch (Exception ex)
            {
                // Log error
                // Return false
                return false;
            }
        }
    }
}