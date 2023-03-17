using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WpfApp.Models.Entitites;
using WpfApp.Services;

namespace WpfApp.ViewModels;

internal partial class AllCasesViewModel : ObservableObject
{
    private readonly CaseHandler _caseHandler = new();

    [ObservableProperty]
    private ObservableCollection<CaseEntity> cases = new ObservableCollection<CaseEntity>();

    public AllCasesViewModel()
    {
        GetCases();
    }

    private void GetCases()
    {
        var result = Task.Run(_caseHandler.GetAllAsync).Result;
        result = result.OrderByDescending(x => x.Created);

        foreach(var _case in result)
            Cases.Add(_case);
    }
}
