using GreenDream.Device.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GreenDream.Device.Data.Extensions
{
    public static class DeviceDataBuilderExtension
    {
        public static void AddDeviceRepository(this IServiceCollection services)
        {
            services.AddTransient<IDeviceRepository, DeviceRepository>();
        }
    }
}