using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceMgmt.API.Models
{
    public class ApplicationDBContext : DbContext
    {
        const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ClientDb;Trusted_Connection=True;";

        public ApplicationDBContext() : base() { }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        //public DbSet<Person> People { get; set; }

       
    }
}
