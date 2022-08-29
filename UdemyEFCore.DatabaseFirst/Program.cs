// See https://aka.ms/new-console-template for more information

using UdemyEFCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;

DbContextInitializer.Build(); // Nesne örneği üretmeden sınıf üzerinden erişebiliriz. Static olarak vermemizin sebebi de bundandır.

using (var _context = new AppDbContext(DbContextInitializer.OptionsBuilder.Options)) // Veritabanı ile ilgili işlemleri buradan gerçekleştireceğiz.
{
    var products = await _context.Products.ToListAsync(); // Veritabanındaki Product tablosu ile haberleş demektir. 


    products.ForEach(p =>
    {

        Console.WriteLine($"{p.Id}: {p.Name}");

    });

}
