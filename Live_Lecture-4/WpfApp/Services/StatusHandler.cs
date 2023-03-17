using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Contexts;
using WpfApp.Models.Entitites;

namespace WpfApp.Services;

internal class StatusHandler
{
    private readonly DataContext _context = new();

    public StatusHandler()
    {
        InitializeAsync().ConfigureAwait(false);
    }

    public async Task<StatusEntity> GetOrCreateAsync(string statusName)
    {
        var _statusEntity = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusName == statusName);
        if (_statusEntity == null)
        {
            _statusEntity = new StatusEntity { StatusName = statusName };
            await _context.AddAsync(_statusEntity);
            await _context.SaveChangesAsync();
        }

        return _statusEntity;
    }

    public async Task<IEnumerable<StatusEntity>> GetAllAsync()
    {
        return await _context.Statuses.ToListAsync();
    }

    private async Task InitializeAsync()
    {
        if (!await _context.Statuses.AnyAsync())
        {
            var statuses = new List<StatusEntity> 
            { 
                new StatusEntity { StatusName = "Not Started" },
                new StatusEntity { StatusName = "Ongoing" },
                new StatusEntity { StatusName = "Closed" }
            };

            await _context.AddRangeAsync(statuses);
            await _context.SaveChangesAsync();
        }
    }
}
