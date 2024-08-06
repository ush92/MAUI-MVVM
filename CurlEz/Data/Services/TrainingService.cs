using CurlEz.Data.Interfaces;
using CurlEz.Models;

namespace CurlEz.Data.Services;

public class TrainingService : ITrainingService
{
    private readonly IAppDbContext _dbContext;

    public TrainingService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Training>> GetTrainingsAsync()
    {
        return _dbContext.GetConnection().Table<Training>().ToListAsync();
    }

    public Task<int> SaveTrainingAsync(Training training)
    {
        return _dbContext.GetConnection().InsertAsync(training);
    }
}
