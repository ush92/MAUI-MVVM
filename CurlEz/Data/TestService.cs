using CurlEz.Models;

namespace CurlEz.Data;

public class TestService : ITestService
{
    private readonly IAppDbContext _dbContext;

    public TestService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Test>> GetTestsAsync()
    {
        return _dbContext.GetConnection().Table<Test>().ToListAsync();
    }

    public Task<int> SaveTestAsync(Test test)
    {
        return _dbContext.GetConnection().InsertAsync(test);
    }
}