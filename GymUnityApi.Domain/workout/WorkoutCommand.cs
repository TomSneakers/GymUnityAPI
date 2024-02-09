using GymUnityApi.Domain.core.ioc;
using GymUnityApi.Domain.exercise.template;

namespace GymUnityApi.Domain.workout;

public class WorkoutCommand
{
    public void AddWorkout(string userId, string name, string description, IEnumerable<ExerciseTemplate> exercices)
    {
        var workout = new WorkoutBuilder().For(userId)
                                            .WithName(name)
                                            .WithDescription(description)
                                            .WithExercises(exercices)
                                            .Build();
        
        Locator.WorkoutRepository().Save(workout);
    }
}