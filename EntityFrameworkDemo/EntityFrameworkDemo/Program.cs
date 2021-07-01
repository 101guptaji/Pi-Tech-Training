using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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


            //Inner join
            //var joinquery1 = from p in db.Products
            //                 join c in db.Categories on
            //                p.CategoryID equals c.CategoryID    select
            //                new { p.ProductName, p.UnitPrice, p.UnitsInStock, c.CategoryName, c.Description };


            //foreach (var item in joinquery1)
            //{
            //    Console.WriteLine(item.ProductName+"\t"+ item.UnitPrice+"\t"+item.UnitsInStock+"\t"+item.CategoryName+"\t"+item.Description);
            //}

            //method syntax ??

            //left join
            //   var leftjoinquery1 = from c in db.Categories
            //                        join p in db.Products
            //on c.CategoryID equals p.CategoryID into Product_data
            //                        from data in Product_data.DefaultIfEmpty()
            //                        orderby c.CategoryName
            //                        select new { c.CategoryName, data.ProductName, data.UnitPrice };

            //   foreach (var item in leftjoinquery1)
            //   {
            //       Console.WriteLine(item.CategoryName+"\t"+item.ProductName + "\t" + item.UnitPrice );
            //   }

            //Method Syntax ??



            //Lazy loading and eager loading

            //default db.Configuration.LazyLoadingEnabled=true
            //catagory wise product count
            ///*db.Configuration.LazyLoadingEnabled = false;*/

            //var lazydata = from cat in db.Categories select cat;

            //foreach (var item in lazydata)
            //{
            //    Console.WriteLine($"For Catagory: {item.CategoryName}, Product count={item.Products.Count()}");
            //}

            //it hit the database for every iteration of catagory name

            //eager loading
            //db.Configuration.LazyLoadingEnabled = false;
            //it loads data table at once

            //var eagerloading = from cat in db.Categories.Include("Products") select cat;

            //foreach (var item in eagerloading)
            //{
            //    Console.WriteLine($"For Catagory: {item.CategoryName}, Product count={item.Products.Count()}");
            //}

            /* DML using LINQ */

            //Product newPro = new Product()
            //{
            //    ProductName = "Almiraa",
            //    CategoryID = 1,
            //    UnitPrice = 100
            //};
            //db.Products.Add(newPro);
            //db.SaveChanges(); /* Apply changes to database

            /* Update using traditional method */
            //Product pro = db.Products.SingleOrDefault(p => p.ProductID == 78);
            //if (pro != null)
            //{
            //    pro.UnitPrice = 150;
            //    pro.UnitsInStock = 0;

            //    db.SaveChanges();
            //}

            //Product updatePro = new Product()
            //{
            //    ProductID = 79,
            //    ProductName = "GreanTea",
            //    UnitPrice=500

            //};
            //db.Entry(updatePro).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();

            /* Delete */
            //Product deletePro = db.Products.SingleOrDefault(p => p.ProductID == 79);
            //if(deletePro!=null)
            //{
            //    db.Products.Remove(deletePro); //delete from DbSet<Product> Collection
            //    db.SaveChanges();
            //}

            /* Stored Procedure */
            var returnData = db.GetProdCount(1);
            Console.WriteLine("Total Product: " + returnData.First());

            /* Stored Procedure with return out */
            ObjectParameter cnt = new ObjectParameter("count", typeof(int));
            db.GetTotalProd(1, cnt);
            Console.WriteLine("Total Product: " + cnt.Value);

            Console.ReadLine();
        }

    }
}
