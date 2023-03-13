using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Contexts;

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
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN22HG\datalagring\Live_Lecture-3\ConsoleApp\Contexts\consoleapp_db.mdf;Integrated Security=True;Connect Timeout=30");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<CommentEntity>()
        //    .HasOne(x => x.User)
        //    .WithMany(x => x.Comments)
        //    .HasForeignKey(x => x.UserId)
        //    .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
    #endregion

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserTypeEntity> UserTypes { get; set; }
    public DbSet<StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CaseEntity> Cases { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
}
