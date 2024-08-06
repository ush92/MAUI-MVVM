using CurlEz.Models;

namespace CurlEz.Data.Interfaces;

public interface IRoutineService
{
    Task<List<Routine>> GetRoutinesAsync();
    Task<List<Routine>> GetRoutinesByTrainingPlanIdAsync(int trainingPlanId);
    Task<int> SaveRoutineAsync(Routine routine);
}
