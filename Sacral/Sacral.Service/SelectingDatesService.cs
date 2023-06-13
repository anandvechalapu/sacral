using Sacral.DataAccess;
using Sacral.DTO;

namespace Sacral.Service
{
    public class SelectingDatesService : ISelectingDatesService
    {
        private readonly DataAccess _dataAccess;

        public SelectingDatesService(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<DTO.SelectingDates> SelectingDates()
        {
            try
            {
                var result = await _dataAccess.SelectingDates();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("HTTP code 502 from API (<html>\r\n<head><title>502 Bad Gateway</title></head>\r\n<body>\r\n<center><h1>502 Bad Gateway</h1></center>\r\n<hr><center>cloudflare</center>\r\n</body>\r\n</html>\r\n)", ex);
            }
        }
    }
}