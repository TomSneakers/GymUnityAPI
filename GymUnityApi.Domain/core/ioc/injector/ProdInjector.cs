using GymUnityApi.Domain.exercise.queryService;
using GymUnityApi.Domain.exercise.queryService.queryRepository;
using GymUnityApi.Domain.exercise.repository;
using GymUnityApi.Domain.workout;
using GymUnityApi.Domain.workout.queryService;
using GymUnityApi.Domain.workout.repository;

namespace GymUnityApi.Domain.core.ioc.injector;

public class ProdInjector : IInjector
{
    public WorkoutQueryService WorkoutQueryService() => new();
    public WorkoutCommand WorkoutCommand() => new();
    public WorkoutQueryRepository WorkoutQueryRepository() => new();
    public WorkoutRepository WorkoutRepository() => new();
    public ExerciseRepository ExerciseRepository() => new();
    public ExerciseQueryRepository ExerciseQueryRepository() => new();
    public ExerciseQueryService ExerciseQueryService() => new();
}