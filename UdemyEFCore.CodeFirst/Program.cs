﻿
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
    context.Entry(product).State = EntityState.Detached; // Buradaki komut ile detached olarak track ettik. Yani bu değişiklik DB'ye yansımayacak. SaveChanges desek bilere DB'de görmeyeceğiz.
    Console.WriteLine($"Son state:{context.Entry(product).State}");

    product.Name = "Kitap 2000";


    await context.SaveChangesAsync();
    Console.WriteLine($"SaveChanges Sonraki state:{context.Entry(product).State}");

    //context.Entry(newProduct).State = EntityState.Added; // Buradaki komut ile await context.AddAsync(newProcuct); komutu aynıdır.
    //await context.AddAsync(newProduct);






}