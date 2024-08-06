using CurlEz.Models;

namespace CurlEz.Data.Interfaces;

public interface IExerciseTypeService
{
    Task<List<ExerciseType>> GetExerciseTypesAsync();
    Task<int> SaveExerciseTypeAsync(ExerciseType exerciseType);
}
