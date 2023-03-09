using _01_SqlClient.Models;
using Microsoft.Data.SqlClient;

namespace _01_SqlClient.Services;

internal class ProductService
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN22HG\datalagring\Live_Lecture-2\01_SqlClient\Data\local_sql_db.mdf;Integrated Security=True;Connect Timeout=30";


    public void Save(Product product)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        using var cmd = new SqlCommand($"IF NOT EXISTS (SELECT Id FROM Products WHERE Name = @Name) INSERT INTO Products VALUES (@Name, @Description, @StockPrice)", conn);
        cmd.Parameters.AddWithValue("@Name", product.Name);
        cmd.Parameters.AddWithValue("@Description", product.Description);
        cmd.Parameters.AddWithValue("@StockPrice", product.Price);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Product> GetAll() 
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        using var cmd = new SqlCommand("SELECT * FROM Products", conn);

        var products = new List<Product>(); 

        var result = cmd.ExecuteReader();
        if (result.HasRows) 
        { 
            while (result.Read())
            {
                products.Add(new Product
                {
                    Id = result.GetInt32(0),
                    Name = result.GetString(1),
                    Description = result.GetString(2),
                    Price = result.GetDecimal(3)
                });
            }
        }

        return products;
    }

    public Product Get(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        using var cmd = new SqlCommand("SELECT * FROM Products WHERE id = @Id", conn);
        cmd.Parameters.AddWithValue("@Id", id);

        var product = new Product();

        var result = cmd.ExecuteReader();
        if (result.HasRows)
        {
            while (result.Read())
            {

                product.Id = result.GetInt32(0);
                product.Name = result.GetString(1);
                product.Description = result.GetString(2);
                product.Price = result.GetDecimal(3);
            }
        }

        return product;
    }
}
