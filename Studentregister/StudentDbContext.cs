﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Studentregister
{
    internal class StudentDbContext : DbContext
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = StudentRegister; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False"; public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}
