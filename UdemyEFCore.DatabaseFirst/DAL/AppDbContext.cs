using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.DatabaseFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // Property ile DB'deki tablo ismi aynı ise EFCore bunu eşleştirir.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // SQL Server'a bağlantı cümleciği.
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UdemyEFCoreDatabaseFirstDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

    }
}
