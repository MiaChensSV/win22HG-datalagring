using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WpfApp.Contexts;
using WpfApp.Models;
using WpfApp.Models.Entities;

namespace WpfApp.Services;

internal class CaseService
{
    private readonly DataContext _context = new DataContext();

    public async Task SaveAsync(CaseAddModel model)
    {
        var caseEntity = new CaseEntity()
        {
            Title = model.Title,
            Description = model.Description,
        };

        if (model.User != null) 
        {
            // check user
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.User.Email);
            if (userEntity != null)
                caseEntity.UserId = userEntity.Id;
            else
            {
                userEntity = new UserEntity
                {
                    FirstName = model.User.FirstName,
                    LastName = model.User.LastName,
                    Email = model.User.Email,
                    PhoneNumber = model.User.PhoneNumber,
                    UserTypeId = (await _context.UserTypes.FirstOrDefaultAsync(x => x.TypeName == model.User.UserType))!.Id,
                    AddressId = (await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == model.User.StreetName))!.Id
                
                };

                _context.Add(userEntity);
                await _context.SaveChangesAsync();

                caseEntity.UserId = userEntity.Id;
            }

        }

        _context.Add(caseEntity);
        await _context.SaveChangesAsync();
    }
}
