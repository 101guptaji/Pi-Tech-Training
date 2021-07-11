using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Service_App
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        NorthwindEntities db = new NorthwindEntities();
        
        public List<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Product getProductById(int productID)
        {
            return db.Products.Where(p => p.ProductID == productID).SingleOrDefault();
        }
    }
}
