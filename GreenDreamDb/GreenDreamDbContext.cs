using GreenDreamDbContext.DeviceEntity;
using Microsoft.EntityFrameworkCore;

namespace GreenDreamDbContext
{
    public class GreenDreamDbContext : DbContext
    {
        #region Constructors
        
        public GreenDreamDbContext()
        {
        }

        public GreenDreamDbContext(
            DbContextOptions<GreenDreamDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        #endregion

        #region Entity DbSets

        public DbSet<Device> Devices { get; set; }
        
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Device
            builder.Entity<Device>(device =>
            {
                device.HasKey(d => d.Id);
                device.HasIndex(x => x.Name)
                    .IsUnique();
                device.Property(x => x.Name)
                    .IsRequired();
            });
        }
        
    }
}