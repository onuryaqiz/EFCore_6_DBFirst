
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build(); // Build methodu ile appsettings.json'u okunabilir hale getirmiş oluyoruz.

using (var context = new AppDbContext())
{
    context.Products.Add(new() { Name = "Kalem 1", Price = 200, Stock = 100, Barcode = 123 });
    context.Products.Add(new() { Name = "Kalem 1", Price = 200, Stock = 100, Barcode = 123 });
    context.Products.Add(new() { Name = "Kalem 1", Price = 200, Stock = 100, Barcode = 123 });

    Console.WriteLine($"Context Id:{context.ContextId}"); // Eğer uygulamada birden fazla context instance varsa contextId kullanılabilir.
   // context.Database
   // context.SaveChanges();
  


}