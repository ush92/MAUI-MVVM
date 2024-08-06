using CurlEz.Data.Interfaces;
using CurlEz.Models;

namespace CurlEz.Data.Services;

public class TrainingExerciseService : ITrainingExerciseService
{
    private readonly IAppDbContext _dbContext;

    public TrainingExerciseService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<TrainingExercise>> GetTrainingExercisesAsync()
    {
        return _dbContext.GetConnection().Table<TrainingExercise>().ToListAsync();
    }

    public Task<int> SaveTrainingExerciseAsync(TrainingExercise trainingExercise)
    {
        return _dbContext.GetConnection().InsertAsync(trainingExercise);
    }
}
