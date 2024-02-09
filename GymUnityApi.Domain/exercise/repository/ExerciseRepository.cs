using GymUnityApi.Domain.core;
using GymUnityApi.Domain.exercise.type;

namespace GymUnityApi.Domain.exercise.repository;

public class ExerciseRepository
{
    public void SaveExercises(IEnumerable<Exercise> exercises, Guid workoutId)
    {
        foreach (var exercise in exercises)
        {
            SaveBaseExercise(exercise, workoutId);
            switch (exercise.Type)
            {
                case ExerciseType.Cardio:
                    SaveCardioExercise((CardioExercise)exercise);
                    break;
                case ExerciseType.Strength:
                    SaveStrengthExercise((StrengthExercise)exercise);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void SaveBaseExercise(Exercise exercise, Guid workoutId)
    {
        var statement = "INSERT INTO exercise VALUES ($1, $2, $3)";
        new PgCommand().ExecuteNonQuery(statement,
            PgType.ToGuid(exercise.Id),
            PgType.ToString(exercise.Name),
            PgType.ToString(exercise.Type.ToString()));
        SaveExerciseTrainingRelation(workoutId, exercise.Id);
    }

    private void SaveCardioExercise(CardioExercise exercise)
    {
        var statemnet = "INSERT INTO cardio_exercise VALUES ($1, $2)";
        new PgCommand().ExecuteNonQuery(statemnet,
            PgType.ToGuid(exercise.Id),
            PgType.ToInt(exercise.Duration));
    }

    private void SaveStrengthExercise(StrengthExercise exercise)
    {
        var statemnet = "INSERT INTO strength_exercise VALUES ($1, $2, $3, $4, $5)";
        new PgCommand().ExecuteNonQuery(statemnet,
            PgType.ToGuid(exercise.Id),
            PgType.ToInt(exercise.Sets),
            PgType.ToInt(exercise.Reps),
            PgType.ToInt(exercise.Weight),
            PgType.ToInt(exercise.RestTime));
    }

    private void SaveExerciseTrainingRelation(Guid workout, Guid exerciseId)
    {
        var statement = "INSERT INTO workout_exercise (workout_id, exercise_id) VALUES ($1, $2)";
        new PgCommand().ExecuteNonQuery(statement,
            PgType.ToGuid(workout),
            PgType.ToGuid(exerciseId));
    }
}