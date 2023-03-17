using System.Collections.Generic;

namespace WpfApp.Models.Entitites;

internal class StatusEntity
{
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;

    public ICollection<CaseEntity> Cases { get; set; } = new List<CaseEntity>();
}
