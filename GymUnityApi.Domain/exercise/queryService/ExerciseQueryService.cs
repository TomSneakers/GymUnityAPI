using GymUnityApi.Domain.core.ioc;
using GymUnityApi.Domain.exercise.queryService.dto;

namespace GymUnityApi.Domain.exercise.queryService;

public class ExerciseQueryService
{
    public IEnumerable<ExercisePreview> GetExercises(string workoutId)
    {
        return Locator.ExerciseQueryRepository().GetExercises(workoutId);
    }
}