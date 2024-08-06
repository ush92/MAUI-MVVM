using CurlEz.Models;

namespace CurlEz.Data.Interfaces;

public interface IExerciseService
{
    Task<List<Exercise>> GetExercisesAsync();
    Task<int> SaveExerciseAsync(Exercise exercise);
}
