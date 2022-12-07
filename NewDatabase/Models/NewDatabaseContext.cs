using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class NewDatabaseContext : DbContext
    {
        public NewDatabaseContext()
        {

        }
        public string? ConnectionString { get {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: false);
                var configuration = builder.Build();
                return configuration.GetConnectionString("NewDatabase");
                
                    } 

        }
        
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Subject> Subject { get; set; }
        public DbSet<Pupil> Pupil { get; set; }
    }
}
