using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenDream.Device.Data.QueryModels.QueryParams;
using GreenDream.Device.Data.QueryModels.QueryResults;

namespace GreenDream.Device.Data.Interfaces
{
    public interface IDeviceRepository
    {
        Task CreateDeviceAsync(SaveDeviceQueryParam queryParam);
        Task UpdateDeviceAsync(Guid id, SaveDeviceQueryParam queryParam);
        Task<GetCompleteDeviceQueryResult> GetDeviceByIdAsync(Guid id);
        Task<List<GetSummaryDeviceQueryResult>> GetDevicesByNameAsync(string name);
        Task DeleteDeviceAsync(Guid id);
        Task<bool> CheckExistDeviceWithId(Guid id);
    }
}