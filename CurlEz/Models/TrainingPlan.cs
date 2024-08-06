using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CurlEz.Models;

public class TrainingPlan
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string? Name { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsCurrent { get; set; }

    [OneToMany("TrainingPlanId")]
    public List<Routine>? Routines { get; set; }
}
