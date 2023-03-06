using _01_TheBasics.Models;

namespace _01_TheBasics.Services;

internal class CustomerService
{
    private List<Customer> _customerList = new List<Customer>();


    public void Create(Customer customer)
    {
        _customerList.Add(customer);
    }

    public Customer Read(string email)
    {
        return _customerList.FirstOrDefault(x => x.Email == email) ?? null!;
    }

    public IEnumerable<Customer> ReadAll()
    {
        return _customerList;
    }

    public void Update()
    {

    }

    public void Delete(Customer customer)
    {
        _customerList.Remove(customer); 
    }
}
