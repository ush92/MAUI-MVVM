using CurlEz.Models;
using SQLite;

namespace CurlEz.Data;

public interface IAppDbContext
{
    Task InitializeAsync();
    SQLiteAsyncConnection GetConnection();
}

public class AppDbContext : IAppDbContext
{
    private const string DatabaseFilename = "curlez.db3";
    private static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    private SQLiteAsyncConnection? _database;

    public async Task InitializeAsync()
    {
        if (_database == null)
        {
            _database = new SQLiteAsyncConnection(DatabasePath);
            await _database.ExecuteAsync("PRAGMA foreign_keys = ON;");
            await _database.CreateTableAsync<Test>();
            await _database.CreateTableAsync<TrainingPlan>();
            await _database.CreateTableAsync<Routine>();
            await _database.CreateTableAsync<ExerciseType>();
            await _database.CreateTableAsync<Exercise>();
            await _database.CreateTableAsync<RoutineExercise>();
            await _database.CreateTableAsync<Training>();
            await _database.CreateTableAsync<TrainingExercise>();

            await AddSampleDataAsync(_database);
        }
    }

    private async Task AddSampleDataAsync(SQLiteAsyncConnection db)
    {
        if (await db.Table<TrainingPlan>().CountAsync() == 0)
        {
            var trainingPlan = new TrainingPlan { Name = "Sample Plan", CreateDate = DateTime.Now, IsCurrent = true };
            await db.InsertAsync(trainingPlan);

            var routines = new List<Routine>
            {
                new Routine { Name = "Routine 1", CreateDate = DateTime.Now, TrainingPlanId = trainingPlan.ID },
                new Routine { Name = "Routine 2", CreateDate = DateTime.Now, TrainingPlanId = trainingPlan.ID }
            };
            await db.InsertAllAsync(routines);
        }
    }

    public SQLiteAsyncConnection GetConnection()
    {
        _database ??= new SQLiteAsyncConnection(DatabasePath);
        return _database;
    }
}