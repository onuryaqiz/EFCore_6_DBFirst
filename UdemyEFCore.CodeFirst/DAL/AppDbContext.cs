using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    // DBContext doğası gereği , Repository Pattern ve Unit Of Work Pattern'ı implemente ediyor.
    // Repository Pattern : Veriyi erişim ile tüm süreci soyutlayan pattern'dır. DBContext bu süreci de bu süreci de soyutladığı için repository pattern de kullanılıyor.
    // Unit Of Work Pattern : DBContext'te gelen default transaction yapısı olduğu için doğal olarak Unit of Work'de implemente etmiş oluyor . 
    // Eğer uygulamamızda çok entity varsa ve temel CRUD işlemleri yapılacaksa generic repository pattern'lar yazarak hepsini tek bir yerden yapabiliriz. 
    // 2. Fayda : Kullanmış olduğumuz mimari yaklaşımın best practices'lerden kaynaklı . Clean Architecture , Domain Driven Design der ki, Core yapı herhangi bir altyapıya veya  kütüphaneye bağlı olmaması gerekir. 
    // Core yapılarda mutlaka IRepository gibi Interface'lerden faydalanırız. Bu Interface'i implemente eden sınıfları dış katmanda belirliyoruz. O zaman DBContext'i kullanamıyoruz.
    // Repository Interface'ini kullanmamız gerekiyor. 
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
