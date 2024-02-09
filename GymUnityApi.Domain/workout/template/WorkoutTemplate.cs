using GymUnityApi.Domain.exercise.template;

namespace GymUnityApi.Domain.workout.template;

public class WorkoutTemplate
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public IEnumerable<ExerciseTemplate> Exercises { get; set; } = new List<ExerciseTemplate>();
}