using CurlEz.Data.Interfaces;
using CurlEz.Models;

namespace CurlEz.Data.Services;

public class ExerciseTypeService : IExerciseTypeService
{
    private readonly IAppDbContext _dbContext;

    public ExerciseTypeService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<ExerciseType>> GetExerciseTypesAsync()
    {
        return _dbContext.GetConnection().Table<ExerciseType>().ToListAsync();
    }

    public Task<int> SaveExerciseTypeAsync(ExerciseType exerciseType)
    {
        return _dbContext.GetConnection().InsertAsync(exerciseType);
    }
}
