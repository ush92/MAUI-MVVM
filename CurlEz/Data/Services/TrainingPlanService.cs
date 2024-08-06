using CurlEz.Data.Interfaces;
using CurlEz.Models;

namespace CurlEz.Data.Services;

public class TrainingPlanService : ITrainingPlanService
{
    private readonly IAppDbContext _dbContext;

    public TrainingPlanService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<TrainingPlan>> GetTrainingPlansAsync()
    {
        return _dbContext.GetConnection().Table<TrainingPlan>().ToListAsync();
    }

    public Task<int> SaveTrainingPlanAsync(TrainingPlan trainingPlan)
    {
        return _dbContext.GetConnection().InsertAsync(trainingPlan);
    }
}
