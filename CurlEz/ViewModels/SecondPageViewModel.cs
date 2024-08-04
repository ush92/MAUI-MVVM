using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CurlEz.Infrastructure;

namespace CurlEz.ViewModels;

[QueryProperty(nameof(DisplayText), "text")]
public partial class SecondPageViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public SecondPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [ObservableProperty]
    private string? displayText;

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.GoBackAsync();
    }
}
