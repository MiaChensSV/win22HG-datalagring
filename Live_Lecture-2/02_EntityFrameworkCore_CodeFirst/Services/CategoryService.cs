using _02_EntityFrameworkCore_CodeFirst.Contexts;
using _02_EntityFrameworkCore_CodeFirst.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _02_EntityFrameworkCore_CodeFirst.Services;

internal class CategoryService
{
    private readonly DataContext _context = new DataContext();

    public async Task<CategoryEntity> GetOrCreateIfNotExistsAsync(string categoryName)
    {
        var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);
        if (categoryEntity == null)
        {
            categoryEntity = new CategoryEntity() { Name = categoryName };
            _context.Add(categoryEntity);
            await _context.SaveChangesAsync();
        }

        return categoryEntity;
    }

    public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task DeleteAsync(string categoryName)
    {
        var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);
        if (categoryEntity != null)
        {
            _context.Remove(categoryEntity);
            await _context.SaveChangesAsync();
        }
    }
}
