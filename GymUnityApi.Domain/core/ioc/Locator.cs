using GymUnityApi.Domain.core.ioc.injector;
using GymUnityApi.Domain.exercise.queryService;
using GymUnityApi.Domain.exercise.queryService.queryRepository;
using GymUnityApi.Domain.exercise.repository;
using GymUnityApi.Domain.workout;
using GymUnityApi.Domain.workout.queryService;
using GymUnityApi.Domain.workout.repository;

namespace GymUnityApi.Domain.core.ioc;

public static class Locator
{
    private static IInjector _injector = new NoneInjector();

    public static void Load(IInjector injector)
    {
        _injector = injector;
    }

    public static WorkoutQueryService WorkoutQueryService() => _injector.WorkoutQueryService();
    public static WorkoutCommand WorkoutCommand() => _injector.WorkoutCommand();
    public static WorkoutQueryRepository WorkoutQueryRepository() => _injector.WorkoutQueryRepository();
    public static WorkoutRepository WorkoutRepository() => _injector.WorkoutRepository();
    public static ExerciseRepository ExerciseRepository() => _injector.ExerciseRepository();
    public static ExerciseQueryRepository ExerciseQueryRepository() => _injector.ExerciseQueryRepository();
    public static ExerciseQueryService ExerciseQueryService() => _injector.ExerciseQueryService();
}