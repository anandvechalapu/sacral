using Sacral.DTO;
namespace Sacral.Service
{
    public interface IDateRepository
    {
        Task<Date> GetByIdAsync(string id);
        Task<IEnumerable<Date>> GetAllAsync();
        Task CreateAsync(Date date);
        Task UpdateAsync(string id, Date date);
        Task DeleteAsync(string id);
    }
}