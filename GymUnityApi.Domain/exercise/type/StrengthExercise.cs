namespace GymUnityApi.Domain.exercise.type;

public class StrengthExercise(string name, int sets, int reps, int weight, int restTime) : Exercise(ExerciseType.Strength ,name)
{
    public int Sets { get; set; } = sets;
    public int Reps { get; set; } = reps;
    public int Weight { get; set; } = weight;
    public int RestTime { get; set; } = restTime;
}