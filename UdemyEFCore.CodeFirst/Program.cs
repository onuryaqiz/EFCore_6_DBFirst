
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build(); // Build methodu ile appsettings.json'u okunabilir hale getirmiş oluyoruz.

using (var context = new AppDbContext())
{
    var products = await context.Products.AsNoTracking().ToListAsync(); // EFCore tarafından tüm datalar Track edilir. // DB'den aldığımız verilerde CRUD işlemleri yapmayacaksak , EFCore tarafından memory'de track etmemesi sağlanır.
                                                                        // RAM'de fazla yer kaplamayı engellmiş oluruz.





    //products.ForEach(p =>
    //{

    //    p.Stock += 100; // EFCore memory'de track ettiği her product'ın memory'sinde Stock'una 100 ekledi. 
    //    Console.WriteLine($"{p.Id} : {p.Name}-{p.Price}-{p.Stock}");


    //});

    context.ChangeTracker.Entries().ToList().ForEach(e => // e memory'de track edilen nesneyi temsil ediyor.


    {
        if (e.Entity is Product product) // is keyword'ü herhangi bir nesnenin başka bir nesneye cast(dönüştürülme) edilip edilmeyeceğini kontrol eder . Edemez ise false olarak döner. true ise dönüştürmüş olduğu nesneyi product'a atar.
        {
            Console.WriteLine($"{product.Id} : {product.Name}-{product.Price}-{product.Stock}");
        }

    }); // Buradaki değişiklik DB'ye yansır . Böylece 10.satırdaki kod gibi memory yormadan değişiklik işlemini yapmış oluruz.

    context.SaveChanges();


}