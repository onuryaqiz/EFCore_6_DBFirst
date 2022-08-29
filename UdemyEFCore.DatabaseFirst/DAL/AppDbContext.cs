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

        public AppDbContext() // Parametre alan Constructor tanımladığımız için Default olarak Constructor tanımladık. İhtiyacımız olabilir. 
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Veritabanı ile ilgili tüm ayarlar DbContextOptions üzerinden yapılacak. Base ile beraber miras aldığımız sınıfın Constructor'ına gönderiyoruz. 
        {

        }
    }
}
