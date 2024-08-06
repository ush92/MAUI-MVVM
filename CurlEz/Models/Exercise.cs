using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CurlEz.Models;

public class Exercise
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string? Name { get; set; }
    public int ExerciseTypeId { get; set; }

    [ManyToOne("ExerciseTypeId")]
    public ExerciseType? ExerciseType { get; set; }

    [OneToMany("ExerciseId")]
    public List<RoutineExercise>? RoutineExercises { get; set; }
}
