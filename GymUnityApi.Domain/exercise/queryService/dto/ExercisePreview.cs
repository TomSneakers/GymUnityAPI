namespace GymUnityApi.Domain.exercise.queryService.dto;

public class ExercisePreview
{
    public string Type { get; set; } = "";
    public string Name { get; set; } = "";
    public int? Duration { get; set; }
    public int? Sets { get; set; }
    public int? Reps{ get; set; }
    public int? Weight { get; set; }
    public int? RestTime { get; set; }
}