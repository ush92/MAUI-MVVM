using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CurlEz.Models;

public class TrainingExercise
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public int TrainingId { get; set; } 
    public int ExerciseId { get; set; } 
    public int Weight { get; set; }
    public int Repetitions { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [ManyToOne(nameof(TrainingId))]
    public Training? Training { get; set; }

    [ManyToOne(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }
}
