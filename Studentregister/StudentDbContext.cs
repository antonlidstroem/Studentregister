using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Studentregister
{
    internal class StudentDbContext : DbContext
    {
        /* Hårdkodad connectionString
         private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = StudentRegister; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False"; 
        */

        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["StudentDb"]);

            /* LOGGNING ALTERNATIV 1
            optionsBuilder.UseLoggerFactory(new LoggerFactory(
                new[] {
                   new DebugLoggerProvider()
            }));
            */

            /* LOGGNING ALTERNATIV 2
            optionsBuilder.LogTo(Console.WriteLine);
            */

            //LOGGNING ALTERNATIV 3
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
    }
}
