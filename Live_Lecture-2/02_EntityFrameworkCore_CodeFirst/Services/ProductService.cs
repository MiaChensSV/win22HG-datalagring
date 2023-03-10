using _02_EntityFrameworkCore_CodeFirst.Contexts;
using _02_EntityFrameworkCore_CodeFirst.Models.Entitites;
using _02_EntityFrameworkCore_CodeFirst.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace _02_EntityFrameworkCore_CodeFirst.Services;

internal class ProductService
{
    private readonly DataContext _context =  new DataContext();
    private readonly CategoryService _categoryService = new CategoryService();


    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products.Include(x => x.Category).ToListAsync();
    }

    public async Task<ProductEntity> GetAsync(string articleNumber)
    {
        var productEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ArticleNumber == articleNumber);
        if (productEntity != null)
            return productEntity;

        return null!;
    }

    public async Task DeleteAsync(string articleNumber)
    {
        var productEntity = await _context.Products.FirstOrDefaultAsync(x => x.ArticleNumber == articleNumber);
        if (productEntity != null)
        {
            _context.Remove(productEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<ProductEntity> CreateAsync(ProductRegistrationForm form)
    {
        if (await _context.Products.AnyAsync(x => x.ArticleNumber == form.ArticleNumber))
            return null!;

        var productEntity = new ProductEntity()
        {
            ArticleNumber = form.ArticleNumber,
            Name = form.Name,
            Description = form.Description,
            StockPrice = form.StockPrice,
            CategoryId = (await _categoryService.GetOrCreateIfNotExistsAsync(form.CategoryName)).Id
        };

        _context.Add(productEntity);
        await _context.SaveChangesAsync();

        return productEntity;
    }
}
