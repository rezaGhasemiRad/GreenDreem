using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenDream.Device.Data.Interfaces;
using GreenDreem.Device.Manager.ApiModels.QueryParams;
using GreenDreem.Device.Manager.ApiModels.QueryResults;
using GreenDreem.Device.Manager.Internfaces;

namespace GreenDreem.Device.Manager
{
    public class DeviceManager : IDeviceManager
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceManager(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task CreateDeviceAsync(SaveDeviceApiModel apiModel)
        {
            var devices = await _deviceRepository.GetDevicesByNameAsync(apiModel.Name);
            if (devices.Count == 0) 
            {
                //TODO : Error handling
            }
            
            await _deviceRepository.CreateDeviceAsync(apiModel.ToQueryParam());
        }

        public async Task UpdateDeviceAsync(Guid id, SaveDeviceApiModel apiModel)
        {
            if (!await _deviceRepository.CheckExistDeviceWithId(id))
            {
                //TODO : Error handling
            }

            await _deviceRepository.UpdateDeviceAsync(id, apiModel.ToQueryParam());
        }

        public async Task<GetCompleteDeviceApiModel> GetDeviceByIdAsync(Guid id)
        {
            var device = await _deviceRepository.GetDeviceByIdAsync(id);
            if (device == null)
            {
                //TODO : Error handling
            }

            return new GetCompleteDeviceApiModel(device);
        }

        public async Task<List<GetSummaryDeviceApiModel>> GetDevicesByNameAsync(string name)
        {
            var devices = await _deviceRepository.GetDevicesByNameAsync(name);
            return devices.Select(x => new GetSummaryDeviceApiModel(x)).ToList();
        }

        public async Task DeleteDeviceAsync(Guid id)
        {
            if (await _deviceRepository.CheckExistDeviceWithId(id))
            {
                //TODO : Error handling
            }

            await _deviceRepository.DeleteDeviceAsync(id);
        }
    }
}