namespace GymUnityApi.Domain.exercise.type;

public class Exercise(ExerciseType type, string name)
{
    public ExerciseType Type { get; set; } = type;
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; } = name;
}