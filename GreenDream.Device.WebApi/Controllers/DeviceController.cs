using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GreenDreem.Device.Manager.ApiModels.QueryParams;
using GreenDreem.Device.Manager.Internfaces;
using Microsoft.AspNetCore.Mvc;

namespace GreenDream.Device.WebApi.Controllers
{
    [Route("Device")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceManager _deviceManager;

        public DeviceController(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeviceAsync([FromBody] SaveDeviceApiModel apiModel)
        {
            await _deviceManager.CreateDeviceAsync(apiModel);
            
            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeviceAsync([FromRoute][Required] Guid id, [FromBody] SaveDeviceApiModel apiModel)
        {
            await _deviceManager.UpdateDeviceAsync(id, apiModel);
            return Ok();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceByIdAsync([FromRoute][Required] Guid id)
        {
            
            return Ok(new
            {
                device = await _deviceManager.GetDeviceByIdAsync(id)
            });
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllDeviceAsync([FromQuery] string name)
        {
            return Ok(new
            {
                devices = await _deviceManager.GetDevicesByNameAsync(name)
            });
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice([FromRoute][Required] Guid id)
        {
            await _deviceManager.DeleteDeviceAsync(id);
            return Ok();
        }
    }
}