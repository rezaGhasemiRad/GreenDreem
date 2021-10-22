using System;

namespace GreenDream.Device.Data.QueryModels.QueryResults
{
    public class GetSummaryDeviceQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public GetSummaryDeviceQueryResult(GreenDreamDbContext.DeviceEntity.Device device)
        {
            Id = device.Id;
            Name = device.Name;
        }
    }
}