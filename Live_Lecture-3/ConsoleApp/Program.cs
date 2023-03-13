using ConsoleApp.Models.Entities;
using ConsoleApp.Services;

var _caseService = new CaseService();
var _datetime = DateTime.Now;
var _case = new CaseEntity
{
    Id = Guid.NewGuid(),
    Created = _datetime,
    Modified = _datetime,
    Title = "Trasig kamera fram på bilen",
    Description = "Glaset på kameran fram har gått sönder pga stenskott.",
    StatusType = new StatusTypeEntity
    {
        StatusName = "Ej påbörjad"
    },
    User = new UserEntity
    {
        Id = Guid.NewGuid(),
        FirstName = "Hans",
        LastName = "Mattin-Lassei",
        Email = "hans@domain.com",
        PhoneNumber = "1234567890",
        UserType = new UserTypeEntity { TypeName = "Customer - Business" },
        Address = new AddressEntity
        {
            StreetName = "Nordkapsvägen 1",
            PostalCode = "13657",
            City = "Vega"
        }
    }
};

var result = await _caseService.SaveAsync(_case);

Console.ReadKey();