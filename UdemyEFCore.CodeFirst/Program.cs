
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build(); // Build methodu ile appsettings.json'u okunabilir hale getirmiş oluyoruz.

using (var context = new AppDbContext())
{
    context.Products.Add(new() { Name = "Kalem 1", Price = 200, Stock = 100, Barcode = 123 });
    context.Products.Add(new() { Name = "Kalem 1", Price = 200, Stock = 100, Barcode = 123 });
    context.Products.Add(new() { Name = "Kalem 1", Price = 200, Stock = 100, Barcode = 123 });


    context.ChangeTracker.Entries().ToList().ForEach(e => // e memory'de track edilen nesneyi temsil ediyor.


    {
        if (e.Entity is Product product) // is keyword'ü herhangi bir nesnenin başka bir nesneye cast(dönüştürülme) edilip edilmeyeceğini kontrol eder . Edemez ise false olarak döner. true ise dönüştürmüş olduğu nesneyi product'a atar.
        {
            if (e.State==EntityState.Added) // CreatedDate yeni bir property olarak eklendiği için Added olduğu zaman State'ini added olarak belirledik. 
            {
                product.CreatedDate = DateTime.Now;
            }
        }

    }); // Buradaki değişiklik DB'ye yansır . Böylece 10.satırdaki kod gibi memory'yi yormadan değişiklik işlemini yapmış oluruz.

    context.SaveChanges(); // Memory'de track edilen data'nın yani product'ın CreatedDate'ini güncelledik. SaveChanges'i override edersek her değişiklikten sonra yukarıdaki kodu yazmamıza gerek kalmaz.


    // var products = await context.Products.AsNoTracking().ToListAsync(); // EFCore tarafından tüm datalar Track edilir. // DB'den aldığımız verilerde CRUD işlemleri yapmayacaksak , EFCore tarafından memory'de track etmemesi sağlanır.
    // RAM'de fazla yer kaplamayı engellemiş oluruz.



    //products.ForEach(p =>
    //{

    //    p.Stock += 100; // EFCore memory'de track ettiği her product'ın memory'sinde Stock'una 100 ekledi. 
    //    Console.WriteLine($"{p.Id} : {p.Name}-{p.Price}-{p.Stock}");


    //});

  


}