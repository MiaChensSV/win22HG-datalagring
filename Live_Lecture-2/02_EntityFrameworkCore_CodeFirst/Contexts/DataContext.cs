using _02_EntityFrameworkCore_CodeFirst.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _02_EntityFrameworkCore_CodeFirst.Contexts;

internal class DataContext : DbContext
{
    #region constructors and overrides
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN22HG\datalagring\Live_Lecture-2\02_EntityFrameworkCore_CodeFirst\Contexts\EntityFrameworkDatabase.mdf;Integrated Security=True;Connect Timeout=30");
    }
    #endregion

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
}
