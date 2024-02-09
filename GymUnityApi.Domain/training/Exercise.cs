namespace GymUnityApi.Domain.training;

public class Exercise(string name)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; } = name;
}