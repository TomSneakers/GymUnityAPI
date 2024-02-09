using GymUnityApi.Domain.exercise.type;

namespace GymUnityApi.Domain.workout;

public class Workout(string ownerId, string title, string description, IEnumerable<Exercise> exercises)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string OwnerId { get; set; } = ownerId;
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public IEnumerable<Exercise> Exercises { get; set; } = exercises;
}