using SQLite;

namespace CurlEz.Models;

public class Test
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string? Name { get; set; }
}
