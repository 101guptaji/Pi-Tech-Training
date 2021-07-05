using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using(EFCFContext db=new EFCFContext())
            {
                Category category = new Category()
                {
                    CategoryId = 101,
                    CategoryName = "Electronics"
                };
                db.Categories.Add(category);
                db.SaveChanges();

                Product p1 = new Product()
                {
                    ProductId=1,
                    ProductName="Mobile",
                    Price=452,
                    Quantity=5,
                    Category=category
                };
                Product p2= new Product()
                {
                    ProductId = 2,
                    ProductName = "Lapto",
                    Price = 30000,
                    Quantity = 3,
                    Category = category
                };
                db.Products.Add(p1);
                db.Products.Add(p2);
                db.SaveChanges();

                Console.WriteLine("Record inserted...");
                Console.ReadLine();
            }
        }
    }
}
