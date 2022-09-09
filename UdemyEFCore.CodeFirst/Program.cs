
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build(); // Build methodu ile appsettings.json'u okunabilir hale getirmiş oluyoruz.

using (var context = new AppDbContext())
{
    //var products = await context.Products.ToListAsync();

    //products.ForEach(p =>
    //{
    //    var state = context.Entry(p).State; // p entity'sinin State'ini verir.
    //    Console.WriteLine($"{p.Id}:{p.Name}:{p.Price}:{p.Stock} state : {state}"); // State : Unchanged : EFCore tarafından listeleme yaptığımızda , DB'den datayı aldığımızda datayı unchanged olarak atar. Yani değişmemiş. 


    //});
    context.Update(new Product() { Id = 5, Name = "Defter", Price = 500, Stock = 500, Barcode = 500 }); // Track edilmeyen bir nesne . EFCore tarafından Track edilmez. Bu nedenle Update methodunu kullanırız!

    //context.Update(product); // Track edilmeyen datalar için var . 

    await context.SaveChangesAsync();
    //Console.WriteLine($"SaveChanges Sonraki state:{context.Entry(product).State}");

    //context.Entry(newProduct).State = EntityState.Added; // Buradaki komut ile await context.AddAsync(newProcuct); komutu aynıdır.
    //await context.AddAsync(newProduct);






}