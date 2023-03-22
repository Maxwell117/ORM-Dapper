using ORM_Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);

departmentRepo.InsertDepartment("John's new Department");

var departments = departmentRepo.GetAllDepartments();

foreach(var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();
}

var productRepo = new DapperProductRepository(conn);
var productToUpdate = productRepo.GetProduct(974);
productToUpdate.Name = "UPDATED!";
productToUpdate.OnSale = true;
productToUpdate.Price = 12.99;
productToUpdate.StockLevel = 1000;
productToUpdate.CategoryID = 1;

productRepo.UpdateProduct(productToUpdate);

productRepo.DeleteProduct(974);




var products = productRepo.GetAllProducts();

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
