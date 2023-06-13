using Sacral.DTO;

namespace Sacral.Service
{
    public interface ISelectingDatesService
    {
        Task<SelectingDates> SelectingDates();
    }
}