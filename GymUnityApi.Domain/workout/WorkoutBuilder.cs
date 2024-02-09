using GymUnityApi.Domain.exercise;
using GymUnityApi.Domain.exercise.template;
using GymUnityApi.Domain.exercise.type;

namespace GymUnityApi.Domain.workout;

public class WorkoutBuilder
{
    private string _name = string.Empty;
    private string _description = string.Empty;
    private IEnumerable<Exercise> _exercices = new List<Exercise>();
    private string _ownerId = "";

    public WorkoutBuilder For(string userId)
    {
        _ownerId = userId;
        return this;
    }

    public WorkoutBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public WorkoutBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public WorkoutBuilder WithExercises(IEnumerable<ExerciseTemplate> exercises)
    {
        _exercices = exercises.Select(ExerciseCreator.Create);
        return this;
    }

    public Workout Build() =>
        new(_ownerId, _name, _description,
            _exercices);
}