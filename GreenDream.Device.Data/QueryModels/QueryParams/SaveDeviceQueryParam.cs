namespace GreenDream.Device.Data.QueryModels.QueryParams
{
    public class SaveDeviceQueryParam
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public GreenDreamDbContext.DeviceEntity.Device ToEntity()
        {
            return new GreenDreamDbContext.DeviceEntity.Device
            {
                Name = Name,
                Description = Description
            };
        }
    }
}