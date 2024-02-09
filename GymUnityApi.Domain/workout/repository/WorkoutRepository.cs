using GymUnityApi.Domain.core;
using GymUnityApi.Domain.core.ioc;

namespace GymUnityApi.Domain.workout.repository;

public class WorkoutRepository
{
    public void Save(Workout workout)
    {
        var statement = "INSERT INTO workout (id, owner_id, title, description) VALUES ($1, $2, $3, $4)";
        new PgCommand().ExecuteNonQuery(statement,
            PgType.ToGuid(workout.Id),
            PgType.ToString(workout.OwnerId),
            PgType.ToString(workout.Title),
            PgType.ToString(workout.Description));

        Locator.ExerciseRepository().SaveExercises(workout.Exercises, workout.Id);
    }
}