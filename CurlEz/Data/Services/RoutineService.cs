using CurlEz.Data.Interfaces;
using CurlEz.Models;

namespace CurlEz.Data.Services;

public class RoutineService : IRoutineService
{
    private readonly IAppDbContext _dbContext;

    public RoutineService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Routine>> GetRoutinesAsync()
    {
        return _dbContext.GetConnection().Table<Routine>().ToListAsync();
    }

    public Task<int> SaveRoutineAsync(Routine routine)
    {
        return _dbContext.GetConnection().InsertAsync(routine);
    }
}
