using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CurlEz.Data;
using CurlEz.Infrastructure;
using CurlEz.Models;
using System.Collections.ObjectModel;

namespace CurlEz.ViewModels
{
    public partial class TestViewModel : ObservableObject
    {
        private readonly ITestService _testService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private ObservableCollection<Test>? tests;

        [ObservableProperty]
        private string? newTestName;

        public TestViewModel(ITestService testService, INavigationService navigationService)
        {
            _testService = testService;
            _navigationService = navigationService;
        }

        [RelayCommand]
        private async Task LoadTestsAsync()
        {
            var testList = await _testService.GetTestsAsync();
            Tests = new ObservableCollection<Test>(testList);
        }

        [RelayCommand]
        private async Task AddTestAsync()
        {
            if (!string.IsNullOrWhiteSpace(NewTestName))
            {
                var newTest = new Test { Name = NewTestName };
                await _testService.SaveTestAsync(newTest);
                Tests?.Add(newTest);
                NewTestName = string.Empty;
            }
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await _navigationService.GoBackAsync();
        }
    }
}