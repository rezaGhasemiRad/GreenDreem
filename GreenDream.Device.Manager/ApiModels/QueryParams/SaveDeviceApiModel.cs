using System.ComponentModel.DataAnnotations;
using GreenDream.Device.Data.QueryModels.QueryParams;

namespace GreenDreem.Device.Manager.ApiModels.QueryParams
{
    public class SaveDeviceApiModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public SaveDeviceQueryParam ToQueryParam()
        {
            return new SaveDeviceQueryParam
            {
                Name = Name,
                Description = Description
            };
        }
    }
}