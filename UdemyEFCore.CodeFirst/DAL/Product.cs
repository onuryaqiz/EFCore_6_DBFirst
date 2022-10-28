using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    [Table("ProductTb",Schema ="products")] // Data Annotations
    public class Product
    {
       
        public int Product_Id { get; set; } // EFcore default olarak primary key alanına karşılık gelecek bir property bekler. ProductId olarak belirtilebilir. Entity ismi ile aynı olacak şekilde.

    
        public string Name { get; set; }
       
        public decimal Price { get; set; } // Not: Tablo oluştuktan sonra Order kullanılsa bile sıralam değişmez ! Önemi yoktur. Order sadece tablo ilk oluşturulduğunda geçerli olabilir. 

        public DateTime? CreatedDate { get; set; }
        public int Stock { get; set; }

        public int Barcode { get; set; }
    }
}
