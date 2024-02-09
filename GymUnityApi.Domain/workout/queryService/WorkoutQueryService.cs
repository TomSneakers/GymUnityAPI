using GymUnityApi.Domain.core.ioc;
using GymUnityApi.Domain.workout.queryService.dto;

namespace GymUnityApi.Domain.workout.queryService;

public class WorkoutQueryService
{
    public IEnumerable<WorkoutPreview> GetWorkouts(string accountId)
    {
        var workoutResult = Locator.WorkoutQueryRepository().GetWorkouts(accountId);

        return workoutResult.Select(workout => new WorkoutPreview
        {
            Id = workout.ToGuid(0),
            Title = workout.ToString(1),
            Description = workout.ToString(2),
            Exercises = Locator.ExerciseQueryService().GetExercises(workout.ToString(0))
        });
    }
}