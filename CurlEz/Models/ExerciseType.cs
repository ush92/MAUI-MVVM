using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CurlEz.Models;

public class ExerciseType
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string? Name { get; set; }

    [OneToMany("ExerciseTypeId")]
    public List<Exercise>? Exercises { get; set; }
}
