using System;

namespace GreenDream.Device.Data.QueryModels.QueryResults
{
    public class GetCompleteDeviceQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GetCompleteDeviceQueryResult(GreenDreamDbContext.DeviceEntity.Device device)
        {
            Id = device.Id;
            Name = device.Name;
            Description = device.Description;
        }
    }
}