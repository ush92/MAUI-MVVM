using CurlEz.Models;

namespace CurlEz.Data.Interfaces;

public interface IRoutineService
{
    Task<List<Routine>> GetRoutinesAsync();
    Task<int> SaveRoutineAsync(Routine routine);
}
