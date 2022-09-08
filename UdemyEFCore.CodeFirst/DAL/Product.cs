using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class Product
    {
        public int Id { get; set; } // EFcore default olarak primary key alanına karşılık gelecek bir property bekler. ProductId olarak belirtilebilir. Entity ismi ile aynı olacak şekilde.

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
