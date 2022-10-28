using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    [Table("ProductTb",Schema ="products")] // Data Annotations
    public class Product
    {
        [Column( Order = 1)]
        public int Id { get; set; } // EFcore default olarak primary key alanına karşılık gelecek bir property bekler. ProductId olarak belirtilebilir. Entity ismi ile aynı olacak şekilde.

        [Column("name2",Order =2)] // Column ile property ismini veririz. TypeName ile nvarchar,char veya varchar verebiliriz. Order ise tablodaki property'lerin sırasını belirlememizi sağlar. Name order =1 dersek tabloda , Name ilk sırada olacaktır.
        public string Name { get; set; }
        [Column("price2", Order = 3,TypeName ="decimal(18,2)")] // Toplam 18 karakter ve virgülden sonra 2 karakter gelecektir. Virgülden önce 16 toplamda 18 karakter
        public decimal Price { get; set; } // Not: Tablo oluştuktan sonra Order kullanılsa bile sıralam değişmez ! Önemi yoktur. Order sadece tablo ilk oluşturulduğunda geçerli olabilir. 

        public DateTime? CreatedDate { get; set; }
        public int Stock { get; set; }

        public int Barcode { get; set; }
    }
}
