using GymUnityApi.Domain.core;
using GymUnityApi.Domain.exercise.queryService.dto;

namespace GymUnityApi.Domain.exercise.queryService.queryRepository;

public class ExerciseQueryRepository
{
    public IEnumerable<ExercisePreview> GetExercises(string workoutId)
    {
        var statement = @"SELECT e.name, e.type, ce.duration, se.sets, se.reps, se.weight, se.rest_time
FROM workout_exercise we
LEFT JOIN exercise e ON e.id = we.exercise_id
LEFT JOIN cardio_exercise ce ON ce.id = we.exercise_id
LEFT JOIN strength_exercise se ON se.id = we.exercise_id
WHERE we.workout_id=$1;";
        var result = new PgCommand().ExecuteDataTable(statement, PgType.ToGuid(workoutId));
        return result.Select(convert => new ExercisePreview
        {
            Name = convert.ToString(0),
            Type = convert.ToString(1),
            Duration = convert.ToNullableInt(2),
            Sets = convert.ToNullableInt(3),
            Reps = convert.ToNullableInt(4),
            Weight = convert.ToNullableInt(5),
            RestTime = convert.ToNullableInt(6)
        });
    }
}