using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenDream.Device.Data.Interfaces;
using GreenDream.Device.Data.QueryModels.QueryParams;
using GreenDream.Device.Data.QueryModels.QueryResults;
using Microsoft.EntityFrameworkCore;

namespace GreenDream.Device.Data
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly GreenDreamDbContext.GreenDreamDbContext _context;

        public DeviceRepository(GreenDreamDbContext.GreenDreamDbContext context)
        {
            _context = context;
        }

        public async Task CreateDeviceAsync(SaveDeviceQueryParam queryParam)
        {
            await _context.Devices.AddAsync(queryParam.ToEntity());
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDeviceAsync(Guid id, SaveDeviceQueryParam queryParam)
        {
            var device = await _context.Devices
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

            if (device == null)
            {
                return;
            }

            device.Name = queryParam.Name;
            device.Description = queryParam.Description;
            
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }

        public async Task<GetCompleteDeviceQueryResult> GetDeviceByIdAsync(Guid id)
        {
            return await _context.Devices.Where(x => x.Id.Equals(id))
                .Select(x => new GetCompleteDeviceQueryResult(x))
                .FirstOrDefaultAsync();
        }

        public async Task<List<GetSummaryDeviceQueryResult>> GetDevicesByNameAsync(string name)
        {
            return await _context.Devices
                .Where(x => string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name.ToLower()))
                .Select(x => new GetSummaryDeviceQueryResult(x))
                .ToListAsync();
        }

        public async Task DeleteDeviceAsync(Guid id)
        {
            var device = await _context.Devices.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (device == null)
            {
                return;
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckExistDeviceWithId(Guid id)
        {
            return await _context.Devices.AnyAsync(x => x.Id.Equals(id));
        }
    }
}