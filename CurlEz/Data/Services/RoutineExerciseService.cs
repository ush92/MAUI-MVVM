using CurlEz.Data.Interfaces;
using CurlEz.Models;

namespace CurlEz.Data.Services;

public class RoutineExerciseService : IRoutineExerciseService
{
    private readonly IAppDbContext _dbContext;

    public RoutineExerciseService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<RoutineExercise>> GetRoutineExercisesAsync()
    {
        return _dbContext.GetConnection().Table<RoutineExercise>().ToListAsync();
    }

    public Task<int> SaveRoutineExerciseAsync(RoutineExercise routineExercise)
    {
        return _dbContext.GetConnection().InsertAsync(routineExercise);
    }
}
