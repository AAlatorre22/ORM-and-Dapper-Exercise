using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Channels;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            #region Department
            //var departmentRepo = new DapperDepartmentRepository(conn);


            //var departments = departmentRepo.GetAllDepartments();

            //foreach (var dept in departments)
            //{
            //    Console.WriteLine(dept.Name);
            //}

            //Console.WriteLine("Type a new Department name");

            //var newDepartment = Console.ReadLine();

            //departmentRepo.InsertDepartment(newDepartment);

            //departmentRepo.GetAllDepartments();

            //foreach (var dept in departments)
            //{
            //    Console.WriteLine(dept.Name);
            //}

            #endregion

            var prodRepo = new DapperProductRepository(conn);

            var products = prodRepo.GetAllProducts();

            //foreach (var prod in products )
            //{
            //    Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
            //}

            Console.WriteLine();

            //Console.WriteLine("What is name of new product?");
            //var prodName = Console.ReadLine();

            //Console.WriteLine("What is price?");
            //var prodPrice = double.Parse(Console.ReadLine());

            //Console.WriteLine("What is Cat ID?");
            //var prodCat = int.Parse(Console.ReadLine());

            //prodRepo.CreateProduct(prodName, prodPrice, prodCat);

            //products = prodRepo.GetAllProducts();

            //Console.WriteLine("All products\n");

            //foreach (var prod in products)
            //{
            //    Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
            //}




            #region Product

            var productRepo = new DapperProductRepository(conn);
            var productToUpdate = productRepo.GetProduct(940);

            productToUpdate.Name = "Updated Alejandro's Secret Stuff";
            productToUpdate.StockLevel = 15;
            productToUpdate.Price = 7000;
            productToUpdate.CategoryID = 2;


            productRepo.UpdateProduct(productToUpdate);

            products = productRepo.GetAllProducts();


            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();

            }
            products = productRepo.GetAllProducts();
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
            }

            #endregion

            Console.WriteLine("What is product you want to delete?");
            var prodID = int.Parse(Console.ReadLine());

            prodRepo.DeleteProduct(prodID);

            products = productRepo.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
            }

        }
    }
}
