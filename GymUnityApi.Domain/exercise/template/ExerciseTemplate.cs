namespace GymUnityApi.Domain.exercise.template;

public class ExerciseTemplate
{
    public string Type { get; set; } = "";
    public string Name { get; set; } = "";
    public int Duration { get; set; } = 0;
    public int Sets { get; set; } = 0;
    public int Reps { get; set; } = 0;
    public int Weight { get; set; } = 0;
    public int RestTime { get; set; } = 0;
}