using CurlEz.Models;

namespace CurlEz.Data.Interfaces;

public interface ITrainingService
{
    Task<List<Training>> GetTrainingsAsync();
    Task<int> SaveTrainingAsync(Training training);
}
