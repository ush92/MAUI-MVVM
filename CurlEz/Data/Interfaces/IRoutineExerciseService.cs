using CurlEz.Models;

namespace CurlEz.Data.Interfaces;

public interface IRoutineExerciseService
{
    Task<List<RoutineExercise>> GetRoutineExercisesAsync();
    Task<int> SaveRoutineExerciseAsync(RoutineExercise routineExercise);
}
