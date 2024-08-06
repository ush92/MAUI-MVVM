using CurlEz.Data.Interfaces;
using CurlEz.Models;

namespace CurlEz.Data.Services;

public class ExerciseService : IExerciseService
{
    private readonly IAppDbContext _dbContext;

    public ExerciseService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Exercise>> GetExercisesAsync()
    {
        return _dbContext.GetConnection().Table<Exercise>().ToListAsync();
    }

    public Task<int> SaveExerciseAsync(Exercise exercise)
    {
        return _dbContext.GetConnection().InsertAsync(exercise);
    }
}
