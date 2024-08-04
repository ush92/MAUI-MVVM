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
            await _database.CreateTableAsync<Models.Test>();
        }
    }

    public SQLiteAsyncConnection GetConnection()
    {
        _database ??= new SQLiteAsyncConnection(DatabasePath);
        return _database;
    }
}