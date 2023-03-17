using System;

namespace WpfApp.Models.Entitites;

internal class CommentEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Created { get; set; } = DateTime.Now;
    public string Comment { get; set; } = null!;

    public Guid CaseId { get; set; }
    public CaseEntity Case { get; set; } = null!;
}
