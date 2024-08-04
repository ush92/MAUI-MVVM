using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CurlEz.Infrastructure;

namespace CurlEz.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public MainPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [ObservableProperty]
    private string? inputText;

    [RelayCommand]
    private async Task Navigate()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "text", InputText ?? string.Empty }
        };
        await _navigationService.NavigateToAsync(Routes.SecondPage, navigationParameter);
    }

    [RelayCommand]
    private async Task NavigateToTestPageAsync()
    {
        await _navigationService.NavigateToAsync(Routes.TestView);
    }
}
