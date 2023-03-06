using _02_FileStorage.Models;

namespace _02_FileStorage.Services;

internal class MenuService
{
    private CustomerService _customerService = new CustomerService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json");

    public void CreateCustomer()
    {
        var customer = new Customer();

        Console.Clear();
        Console.Write("Förnamn: ");
        customer.FirstName = Console.ReadLine() ?? "";

        Console.Write("Efternamn: ");
        customer.LastName = Console.ReadLine() ?? "";

        Console.Write("E-postadress: ");
        customer.Email = Console.ReadLine() ?? "";

        _customerService.Create(customer);


        var customers = _customerService.GetCustomers();
    }

    public void ViewCustomers()
    {
        Console.Clear();
        foreach(var customer in _customerService.GetCustomers())
            Console.WriteLine($"{customer.FirstName} {customer.LastName} <{customer.Email}>");
    }
}
