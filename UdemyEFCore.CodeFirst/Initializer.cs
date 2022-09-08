using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst
{
    public class Initializer
    {
        public static IConfigurationRoot Configuration; // ASP.NET Configuration sınıfı hazır bir şekilde geliyor. Bu şekilde Consol'da oluşturuyoruz.
        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile
                ("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}
