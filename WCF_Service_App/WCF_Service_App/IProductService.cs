using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Service_App
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract] //mark ur inteface as a service contract
    public interface IProductService
    {
        [OperationContract] //mark ur method as a part of ur service contract
        //void DoWork();
        List<Product> GetAllProducts();

        [OperationContract]
        Product getProductById(int productID);

    }
}
