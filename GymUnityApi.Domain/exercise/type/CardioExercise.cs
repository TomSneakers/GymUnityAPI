namespace GymUnityApi.Domain.exercise.type;

public class CardioExercise(string name, int duration) : Exercise(ExerciseType.Cardio, name)
{
    public int Duration { get; set; } = duration;
}