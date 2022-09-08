using Microsoft.EntityFrameworkCore;
using UdemyEFCore.DatabaseFirstByScaffold.Models;

// DB First yaklaşımını, uygulama geliştireceğimiz zaman , DB hazır ise , Entity'leri Scaffold ile DB'ye taşıyabiliriz. Manuel olarak DB'ye ekleme yapılmamalı. Sonraki aşamalarda yani ,
// entity'ler DB'ye eklendikten sonra ,CodeFirst olarak devam edilmeli . DB First'te otomatik olarak devam edersek de , var olan yapıları override ederek ezer ve hata alabiliriz.



using (var context = new UdemyEFCoreDatabaseFirstDbContext())
{
    var products = await context.Products.ToListAsync(); // Veritabanındaki Product tablosu ile haberleş demektir. 


    products.ForEach(p =>
    {

        Console.WriteLine($"{p.Id}: {p.Name} -  {p.Stock.HasValue} - {p.Price}");

    });
}