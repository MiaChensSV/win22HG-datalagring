using System;
using System.Collections.Generic;

namespace WpfApp.Models.Entitites;

internal class CaseEntity
{
    public CaseEntity()
    {
        var datetime = DateTime.Now;

        Id = Guid.NewGuid();
        Created = datetime;
        Modified = datetime;
        Subject = null!;
        Description = null!;
        StatusId = 1;

        Customer = null!;
        Status = null!;
        Comments = new List<CommentEntity>();
    }

    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }


    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; }


    public int StatusId { get; set; }
    public StatusEntity Status { get; set; }

    public ICollection<CommentEntity> Comments { get; set; }
}
