using System.Threading.Tasks;
using WpfApp.Contexts;
using WpfApp.Models.Entitites;

namespace WpfApp.Services;

internal class CommentHandler
{
    private readonly DataContext _context = new();
    private readonly CaseHandler _caseHandler = new();

    public async Task CreateAsync(CommentEntity commentEntity)
    {
        if (commentEntity != null)
        {
            await _context.AddAsync(commentEntity);
            await _context.SaveChangesAsync();

            await _caseHandler.UpdateAsync(commentEntity.CaseId);
        }
    }

}
