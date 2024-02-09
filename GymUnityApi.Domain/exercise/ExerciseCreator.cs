using GymUnityApi.Domain.exercise.template;
using GymUnityApi.Domain.exercise.type;

namespace GymUnityApi.Domain.exercise;

public static class ExerciseCreator
{
    public static Exercise Create(ExerciseTemplate template)
    {
        var exerciseType = Enum.Parse<ExerciseType>(template.Type);
        return exerciseType switch
        {
            ExerciseType.Cardio => new CardioExercise(template.Name, template.Duration),
            ExerciseType.Strength => new StrengthExercise(template.Name, template.Sets, template.Reps,
                template.Weight, template.RestTime),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}