using CurlEz.Models;

namespace CurlEz.Data.Interfaces;

public interface ITrainingPlanService
{
    Task<List<TrainingPlan>> GetTrainingPlansAsync();
    Task<int> SaveTrainingPlanAsync(TrainingPlan trainingPlan);
}
