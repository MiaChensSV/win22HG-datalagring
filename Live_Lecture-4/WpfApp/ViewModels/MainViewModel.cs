using CommunityToolkit.Mvvm.ComponentModel;
using WpfApp.Services;

namespace WpfApp.ViewModels;

internal partial class MainViewModel : ObservableObject
{
    private readonly NavigationHandler _navigationHandler;

    public MainViewModel(NavigationHandler navigationHandler)
    {
        _navigationHandler = navigationHandler;
        _navigationHandler.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    public ObservableObject CurrentViewModel => _navigationHandler.CurrentViewModel!;

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
