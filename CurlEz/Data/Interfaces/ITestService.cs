using CurlEz.Models;

namespace CurlEz.Data.Interfaces;

public interface ITestService
{
    Task<List<Test>> GetTestsAsync();
    Task<int> SaveTestAsync(Test test);
}
