using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal interface IProductRepository
    {
       IEnumerable<Product> GetAllProducts();

        public Product GetProduct(int id);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int productID);
        public void CreateProduct(string name, double price, int categoryID);

    }
}
