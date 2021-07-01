using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //object of DBContext class which will communicate with database
            //perform all CRUD operations
            NorthwindEntities db = new NorthwindEntities();
            
            //SQL query running in background
            db.Database.Log = Console.WriteLine;

            //print all product data
            //LINQ - LINQ to entity

            //IEnumerable<Product> query1 = from p in db.Products select p;

            //foreach (Product item in query1)
            //{
            //    Console.WriteLine(item.ProductID+ "\t"+item.ProductName+"\t"+item.UnitPrice);

            //}

            //list product with product id=5
            //Product item = (from p in db.Products where p.ProductID == 5 select p).SingleOrDefault();
            //Console.WriteLine(item.ProductID + "\t" + item.ProductName + "\t" + item.UnitPrice);
            //Console.ReadLine();

            var joinquery1 = from p in db.Products
                             join c in db.Categories on
                            p.CategoryID equals c.CategoryID    select
                            new { p.ProductName, p.UnitPrice, p.UnitsInStock, c.CategoryName, c.Description };

            foreach (var item in joinquery1)
            {
                Console.WriteLine(item.ProductName+"\t"+ item.UnitPrice+"\t"+item.UnitsInStock+"\t"+item.CategoryName+"\t"+item.Description);
            }


            Console.ReadLine();
        }

    }
}
