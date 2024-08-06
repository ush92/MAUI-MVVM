using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CurlEz.Models;

public class Routine
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string? Name { get; set; }
    public DateTime CreateDate { get; set; }
    public int TrainingPlanId { get; set; }

    [ManyToOne(nameof(TrainingPlanId))]
    public TrainingPlan? TrainingPlan { get; set; }

    [OneToMany("RoutineId")]
    public List<RoutineExercise>? RoutineExercises { get; set; }
}
