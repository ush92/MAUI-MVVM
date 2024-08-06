using CurlEz.Models;

namespace CurlEz.Data.Interfaces;

public interface ITrainingExerciseService
{
    Task<List<TrainingExercise>> GetTrainingExercisesAsync();
    Task<int> SaveTrainingExerciseAsync(TrainingExercise trainingExercise);
}
