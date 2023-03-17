using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Contexts;
using WpfApp.Models;
using WpfApp.Models.Entitites;

namespace WpfApp.Services;

internal class CustomerHandler
{
    private readonly DataContext _context = new();

    public async Task<CustomerEntity> GetOrCreateAsync(CustomerModel model)
    {
        var _customerEntity = await _context.Customers.FirstOrDefaultAsync(x => x.Email == model.Email);
        if (_customerEntity == null)
        {
            _customerEntity = new CustomerEntity 
            { 
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };
            
            await _context.AddAsync(_customerEntity);
            await _context.SaveChangesAsync();
        }

        return _customerEntity;
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }
}
