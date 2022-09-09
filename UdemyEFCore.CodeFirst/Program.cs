
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
    var product = await context.Products.FirstAsync();
    Console.WriteLine($"İlk state:{context.Entry(product).State}");

    context.Remove(product);
    //context.Entry(product).State = EntityState.Deleted;
    Console.WriteLine($"Son state:{context.Entry(product).State}"); // EFCore DB'den datayı okuğunda unchanged state veriyor. Memory'nin stage etmediğine de detach deniyor. Track edilmeyen Detached olarak geliyor.

    await context.SaveChangesAsync();
    Console.WriteLine($"SaveChanges Sonraki state:{context.Entry(product).State}"); // Bu sefer de delete işlemi yaptığımız için Detached oldu . Artık bu data DB'de silindiği için datayı yakalayamadı.EFCore tarafından Track edilmiyor kısacası.

    //context.Entry(newProduct).State = EntityState.Added; // Buradaki komut ile await context.AddAsync(newProcuct); komutu aynıdır.
    //await context.AddAsync(newProduct);






}