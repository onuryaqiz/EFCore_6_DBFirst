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
    // Repository Pattern : Veriyi erişim ile tüm süreci soyutlayan pattern'dır. DBContext bu süreci de soyutladığı için repository pattern de kullanılıyor.
    // Unit Of Work Pattern : DBContext'te gelen default transaction yapısı olduğu için doğal olarak Unit of Work'de implemente etmiş oluyor . 
    // Eğer uygulamamızda çok entity varsa ve temel CRUD işlemleri yapılacaksa generic repository pattern'lar yazarak hepsini tek bir yerden yapabiliriz. 
    // 2. Fayda : Kullanmış olduğumuz mimari yaklaşımın best practices'lerden kaynaklı . Clean Architecture , Domain Driven Design der ki, Core yapının herhangi bir altyapıya veya  kütüphaneye bağlı olmaması gerekir. 
    // Core yapılarda mutlaka IRepository gibi Interface'lerden faydalanırız. Bu Interface'i implemente eden sınıfları dış katmanda belirliyoruz. O zaman DBContext'i kullanamıyoruz.
    // Repository Interface'ini kullanmamız gerekiyor. 
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // Tablo ismini property isminden çıkartacak.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build(); // Sadece Console'da yapılıyor. Diğerlerinde yapmamıza gerek yok ! Worker servislerde de bunu tanımlamamıza gerek yoktur. 
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon")); // veritabanı yolu 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Fluent API
        {
            // modelBuilder.Entity<Product>().ToTable("ProductTBB", "productstbb"); // Fluent API ile tabloları ekleme .

            modelBuilder.Entity<Product>().HasKey(x => x.Product_Id); //  Property üzerine Key yazmak ile buradaki işlem aynıdır. Buradaki Fluent API'dir. Key ise Data Annotations attribute'tur.
        }
        public override int SaveChanges() // Ortak olan yapıları SaveChanges'ten önce state göre atayabiliriz. CreatedDate Added olduğu için yazmadığımız halde DB'ye eklemiş oldu.
        {
            ChangeTracker.Entries().ToList().ForEach(e => 


            {
                if (e.Entity is Product product)
                { 
                if (e.State == EntityState.Added) 
                {
                    product.CreatedDate = DateTime.Now;
                }
            }

        }); 

            return base.SaveChanges();
        }
    }
}
