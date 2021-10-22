using GreenDream.Device.Data.Extensions;
using GreenDreem.Device.Manager.Internfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GreenDreem.Device.Manager.Extensions
{
    public static class DeviceManagerBuilderExtension
    {
        public static void AddDeviceManager(this IServiceCollection services)
        {
            services.AddDeviceRepository();

            services.AddTransient<IDeviceManager, DeviceManager>();
        }
    }
}