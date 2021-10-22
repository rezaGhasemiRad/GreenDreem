using System;
using GreenDream.Device.Data.QueryModels.QueryResults;

namespace GreenDreem.Device.Manager.ApiModels.QueryResults
{
    public class GetSummaryDeviceApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GetSummaryDeviceApiModel(GetSummaryDeviceQueryResult device)
        {
            Id = device.Id;
            Name = device.Name;
            Description = "";
        }
    }
}