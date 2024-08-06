using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CurlEz.Models;

public class Training
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int RoutineId { get; set; }

    [ManyToOne("RoutineId")]
    public Routine? Routine { get; set; }

    [OneToMany("TrainingId")]
    public List<TrainingExercise>? TrainingExercises { get; set; }
}
