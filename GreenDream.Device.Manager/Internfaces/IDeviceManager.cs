using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenDreem.Device.Manager.ApiModels.QueryParams;
using GreenDreem.Device.Manager.ApiModels.QueryResults;

namespace GreenDreem.Device.Manager.Internfaces
{
    public interface IDeviceManager
    {
        Task CreateDeviceAsync(SaveDeviceApiModel apiModel);
        Task UpdateDeviceAsync(Guid id, SaveDeviceApiModel apiModel);
        Task<GetCompleteDeviceApiModel> GetDeviceByIdAsync(Guid id);
        Task<List<GetSummaryDeviceApiModel>> GetDevicesByNameAsync(string name);
        Task DeleteDeviceAsync(Guid id);
    }
}