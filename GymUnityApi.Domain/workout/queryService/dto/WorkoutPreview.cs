using GymUnityApi.Domain.exercise.queryService.dto;

namespace GymUnityApi.Domain.workout.queryService.dto;

public class WorkoutPreview
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public int ExerciseCount { get; set; }
    public string Description { get; set; } = "";
    public IEnumerable<ExercisePreview> Exercises { get; set; } = new List<ExercisePreview>();
}