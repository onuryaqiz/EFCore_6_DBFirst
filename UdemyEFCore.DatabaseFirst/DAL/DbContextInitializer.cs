using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.DatabaseFirst.DAL
{

    public class DbContextInitializer
    {
        public static IConfigurationRoot Configuration; // appsettings.json'ı okuyabilmek için . 
        public static DbContextOptionsBuilder<AppDbContext> OptionsBuilder; // Veritabanı ile ilgili işlemler için.

        public static void Build() // Static olarak tanımlamamızın sebebi , Build'e nesne örneği oluşturmadan , DbContextInitializer üzerinden nokta(.) ile erişim sağlamak istedik. Options ile ayarlar 1 kere set edilecek.
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); // Assembly içindeki uygulamanın çalıştığı klasörü al , appsettings.json dosyasını al . Bu dosya her zaman olmayacağı için , true yaptık. Bu dosya olabilir veya olmayabilir. Dosyada her değişiklikte yüklensin mi ? true. 

            Configuration = builder.Build();
            //OptionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // AppDbContext'te override ettiğimiz için buraya gerek kalmadı . 
            //OptionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlCon"));

        }
    }
}
