using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Contexts;
using WpfApp.Models;
using WpfApp.Models.Entitites;

namespace WpfApp.Services;

internal class CaseHandler
{
    private readonly DataContext _context = new();
    private readonly StatusHandler _statusHandler = new();
    private readonly CustomerHandler _customerHandler = new();

    public async Task<CaseEntity> CreateAsync(CaseModel model)
    {
        var _caseEntity = new CaseEntity
        {
            CustomerId = (await _customerHandler.GetOrCreateAsync(model.Customer)).Id,
            Subject = model.Subject,
            Description = model.Description
        };

        await _context.AddAsync(_caseEntity);
        await _context.SaveChangesAsync();
        
        return _caseEntity;
    }

    public async Task<IEnumerable<CaseEntity>> GetAllAsync()
    {
        return await _context.Cases
            .Include(x => x.Customer)
            .Include(x => x.Status)
            .Include(x => x.Comments)
            .ToListAsync();
    }

    public async Task<CaseEntity> GetAsync(Guid id)
    {
        var _caseEntity = await _context.Cases
            .Include(x => x.Customer)
            .Include(x => x.Status)
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(x => x.Id == id);

        return _caseEntity!;      
    }

    public async Task<CaseEntity> UpdateAsync(Guid id, string statusName)
    {
        var _caseEntity = await GetAsync(id);

        if (_caseEntity != null) 
        { 
            _caseEntity.StatusId = (await _statusHandler.GetOrCreateAsync(statusName)).Id;
            _caseEntity.Modified = DateTime.Now;

            _context.Update(_caseEntity);
            await _context.SaveChangesAsync();
        }

        return _caseEntity!;
    }
}
