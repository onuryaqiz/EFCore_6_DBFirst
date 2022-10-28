
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build(); // Build methodu ile appsettings.json'u okunabilir hale getirmiş oluyoruz.

using (var context = new AppDbContext())
{


    var products = context.Products.ToList();
    products.ForEach(p =>
    {
        p.Stock += 100; // burada modified track edildiği için aşağıdaki koda gerek yoktur ! Stock'ları 100 100 artırdık .

        // context.Products.Update(p); buna gerek yok !

    });

   context.ChangeTracker.Entries().ToList().ForEach(e =>


    {
        if (e.Entity is Product product)
        {
            Console.WriteLine(e.State);
        }

    });


    //var product = context.Products.First(); // Update methodu için 

    //product.Name = "kalem 100";
    //product.Price = 200;

    //context.Update(product); Bunu EFCore tarafından track edilmiş bir metod var ise Update yazmaya gerek yoktur. Update methodu EFCore tarafından Track edilmeyen nesnelere yazılabilir.
    context.SaveChanges();



}