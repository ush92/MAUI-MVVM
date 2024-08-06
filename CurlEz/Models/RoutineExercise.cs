using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CurlEz.Models;

public class RoutineExercise
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public int ExerciseId { get; set; }
    public int RoutineId { get; set; }

    [ManyToOne(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }

    [ManyToOne(nameof(RoutineId))]
    public Routine? Routine { get; set; }
}
