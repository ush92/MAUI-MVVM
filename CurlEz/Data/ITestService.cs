using CurlEz.Models;

namespace CurlEz.Data;

public interface ITestService
{
    Task<List<Test>> GetTestsAsync();
    Task<int> SaveTestAsync(Test test);
}
