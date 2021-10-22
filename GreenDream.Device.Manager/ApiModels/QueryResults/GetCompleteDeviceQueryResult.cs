using System;
using GreenDream.Device.Data.QueryModels.QueryResults;

namespace GreenDreem.Device.Manager.ApiModels.QueryResults
{
    public class GetCompleteDeviceApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GetCompleteDeviceApiModel(GetCompleteDeviceQueryResult device)
        {
            Id = device.Id;
            Name = device.Name;
            Description = device.Description;
        }
    }
}