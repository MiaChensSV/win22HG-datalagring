using _02_FileStorage.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace _02_FileStorage.Services;

internal class CustomerService
{
    private List<Customer> _customers = new List<Customer>();
    private FileService _fileService;

    public CustomerService(string filePath)
    {
        _fileService = new FileService(filePath);
        GetCustomersFromFile();
    }

    public void Create(Customer customer)
    {
        if (customer != null && !_customers.Any(x => x.Email == customer.Email))
        {
            _customers.Add(customer);
            _fileService.Save(JsonConvert.SerializeObject(_customers));
        }                    
    }

    public IEnumerable<Customer> GetCustomers()
    {
        GetCustomersFromFile();
        return _customers!;
    } 


    private void GetCustomersFromFile()
    {
        try { _customers = JsonConvert.DeserializeObject<List<Customer>>(_fileService.Read())!; }
        catch (Exception ex) 
        {
            _customers = new List<Customer>();
            Debug.WriteLine(ex.Message); 
        }
    }
}
