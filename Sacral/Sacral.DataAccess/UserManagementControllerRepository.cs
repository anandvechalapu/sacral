using MongoDB.Driver;
using Sacral.DTO;

namespace Sacral
{
    public class UserManagementControllerRepository : IUserManagementControllerRepository
    {
        private readonly IMongoCollection<UserManagementControllerModel> _userManagementController;
        public UserManagementControllerRepository(INCB_DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _userManagementController = database.GetCollection<UserManagementControllerModel>(settings.UserManagementControllerCollectionName);
        }

        public async Task<IEnumerable<UserManagementControllerModel>> GetAllAsync()
        {
            return await _userManagementController.Find(user => true).ToListAsync();
        }

        public async Task<UserManagementControllerModel> GetByIdAsync(int id)
        {
            return await _userManagementController.Find<UserManagementControllerModel>(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(UserManagementControllerModel user)
        {
            await _userManagementController.InsertOneAsync(user);
        }

        public async Task<bool> UpdateAsync(UserManagementControllerModel user)
        {
            var filter = Builders<UserManagementControllerModel>.Filter.Eq(s => s.Id, user.Id);
		    var result = await _userManagementController.ReplaceOneAsync(filter, user);

		    return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var filter = Builders<UserManagementControllerModel>.Filter.Eq(s => s.Id, id);
		    var result = await _userManagementController.DeleteOneAsync(filter);

		    return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}