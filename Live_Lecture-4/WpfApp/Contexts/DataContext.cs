using Microsoft.EntityFrameworkCore;
using WpfApp.Models.Entitites;

namespace WpfApp.Contexts;

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
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN22HG\datalagring\Live_Lecture-4\WpfApp\Contexts\wpfapp_database.mdf;Integrated Security=True;Connect Timeout=30");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    #endregion

    public DbSet<CaseEntity> Cases { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }
}
