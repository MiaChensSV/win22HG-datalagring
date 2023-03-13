using System;
using System.Collections.Generic;

namespace WpfApp.Models;

internal class CaseModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!;
    public UserModel User { get; set; } = null!;

    public IEnumerable<CommentModel> Comments { get; set; } = new List<CommentModel>();
}
