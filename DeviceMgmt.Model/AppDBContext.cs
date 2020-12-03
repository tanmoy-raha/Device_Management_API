using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DeviceMgmt.Model.DataSet1;

namespace DeviceMgmt.Model
{
    public class ApplicationDBContext : DbContext
    {
        //const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ClientDb;Trusted_Connection=True;";

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Backend> Backends { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceBackend> DeviceBackends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backend>().ToTable("Backend");
            modelBuilder.Entity<Device>().ToTable("Device");
            modelBuilder.Entity<DeviceBackend>().ToTable("DeviceBackend");
        }
    }
}
