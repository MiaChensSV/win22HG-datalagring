using _01_SqlClient.Models;
using Microsoft.Data.SqlClient;

namespace _01_SqlClient.Services;

internal class CustomerService
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN22HG\datalagring\Live_Lecture-2\01_SqlClient\Data\local_sql_db.mdf;Integrated Security=True;Connect Timeout=30";
    private readonly AddressService _addressService = new AddressService();

    public int Save(RegistrationForm form)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        var customer = new Customer
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            //AddressId = _addressService.Save(new Address { StreetName = form.StreetName, PostalCode = form.PostalCode, City = form.City }),
        };
        
        using var cmd = new SqlCommand($"IF NOT EXISTS (SELECT Id FROM Customers WHERE Email = @Email) INSERT INTO Customers OUTPUT inserted.Id VALUES (@FirstName, @LastName, @Email, @AddressId)", conn);
        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
        cmd.Parameters.AddWithValue("@Email", customer.Email);
        cmd.Parameters.AddWithValue("@AddressId", customer.AddressId);

        try { return int.Parse(cmd.ExecuteScalar().ToString()!); }
        catch { return -1; }
    }

    public IEnumerable<CustomerModel> GetAll()
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        using var cmd = new SqlCommand("SELECT c.Id, c.FirstName, c.LastName, c.Email, a.SteetName, a.PostalCode, a.City FROM Customers c JOIN Addresses a ON c.AddressId = a.Id", conn);

        var customers = new List<CustomerModel>();

        var result = cmd.ExecuteReader();
        if (result.HasRows)
        {
            while (result.Read())
            {
                customers.Add(new CustomerModel
                {
                    Id = result.GetInt32(0),
                    FirstName = result.GetString(1),
                    LastName = result.GetString(2),
                    Email = result.GetString(3),
                    StreetName = result.GetString(4),
                    PostalCode = result.GetString(5),
                    City = result.GetString(6)
                });
            }
        }

        return customers;


    }

    public CustomerModel Get(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        using var cmd = new SqlCommand("SELECT c.Id, c.FirstName, c.LastName, c.Email, a.SteetName, a.PostalCode, a.City FROM Customers c JOIN Addresses a ON c.AddressId = a.Id WHERE c.Id = @Id", conn);
        cmd.Parameters.AddWithValue("@Id", id);

        var customer = new CustomerModel();

        var result = cmd.ExecuteReader();
        if (result.HasRows)
        {
            while (result.Read())
            {
                customer.Id = result.GetInt32(0);
                customer.FirstName = result.GetString(1);
                customer.LastName = result.GetString(2);
                customer.Email = result.GetString(3);
                customer.StreetName = result.GetString(4);
                customer.PostalCode = result.GetString(5);
                customer.City = result.GetString(6);
            }

            return customer;
        }

        return null!;
    }
}
