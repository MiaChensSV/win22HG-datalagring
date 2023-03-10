namespace _02_EntityFrameworkCore_CodeFirst.Models.Entitites;

internal class CategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}
