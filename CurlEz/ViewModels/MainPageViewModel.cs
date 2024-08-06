using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CurlEz.Data.Interfaces;
using CurlEz.Infrastructure;
using CurlEz.Models;
using System.Collections.ObjectModel;

namespace CurlEz.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IRoutineService _routineService;
    private readonly ITrainingPlanService _trainingPlanService;

    [ObservableProperty]
    private ObservableCollection<Routine>? routines;

    public MainPageViewModel(INavigationService navigationService, IRoutineService routineService, ITrainingPlanService trainingPlanService)
    {
        _navigationService = navigationService;
        _routineService = routineService;
        _trainingPlanService = trainingPlanService;

        LoadRoutinesAsync().ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task LoadRoutinesAsync()
    {
        var currentPlan = (await _trainingPlanService.GetTrainingPlansAsync()).FirstOrDefault(tp => tp.IsCurrent);
        if (currentPlan != null)
        {
            var routinesList = await _routineService.GetRoutinesByTrainingPlanIdAsync(currentPlan.ID);
            Routines = new ObservableCollection<Routine>(routinesList);
        }
    }

    [RelayCommand]
    private async Task AddRoutineAsync(string routineName)
    {
        if (!string.IsNullOrWhiteSpace(routineName))
        {
            var currentPlan = (await _trainingPlanService.GetTrainingPlansAsync()).FirstOrDefault(tp => tp.IsCurrent);
            if (currentPlan != null)
            {
                var newRoutine = new Routine
                {
                    Name = routineName,
                    TrainingPlanId = currentPlan.ID,
                    CreateDate = DateTime.Now
                };
                await _routineService.SaveRoutineAsync(newRoutine);
                Routines?.Add(newRoutine);
            }
        }
    }
}
