namespace WpfApp.Models;

internal class CaseAddModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public UserModel User { get; set; } = null!;
}
