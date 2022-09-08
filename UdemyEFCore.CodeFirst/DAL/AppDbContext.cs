using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // Tablo isminin property isminden çıkartacak.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build(); // Sadece Console'da yapılıyor. Diğerlerinde yapmamıza gerek yok ! Worker servislerde de bunu tanımlamamıza gerek yoktur. 
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon")); // veritabanı yolu 
        }

    }
}
