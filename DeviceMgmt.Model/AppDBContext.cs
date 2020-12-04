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
        
        public DbSet<DeviceMgmt_Backend> DeviceMgmt_Backends { get; set; }
        public DbSet<DeviceMgmt_Device> DeviceMgmt_Devices { get; set; }
        public DbSet<DeviceMgmt_DeviceBackend> DeviceMgmt_DeviceBackends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceMgmt_Backend>().ToTable("DeviceMgmt_Backend");
            modelBuilder.Entity<DeviceMgmt_Device>().ToTable("DeviceMgmt_Device");
            modelBuilder.Entity<DeviceMgmt_DeviceBackend>().ToTable("DeviceMgmt_DeviceBackend");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"data source=.;initial catalog=DeviceMgmt;user id=sa;password=123;Integrated Security=True");
        }
    }
}
