namespace WpfApp.Models;

internal class CaseModel
{
    public CustomerModel Customer { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Description { get; set; } = null!;
}
