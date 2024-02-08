namespace GymUnityApi.Domain.training.queryService.dto;

public class TrainingPreview
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public int ExerciseCount { get; set; }
}