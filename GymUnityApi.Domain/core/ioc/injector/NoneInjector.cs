using GymUnityApi.Domain.exercise.queryService;
using GymUnityApi.Domain.exercise.queryService.queryRepository;
using GymUnityApi.Domain.exercise.repository;
using GymUnityApi.Domain.workout;
using GymUnityApi.Domain.workout.queryService;
using GymUnityApi.Domain.workout.repository;

namespace GymUnityApi.Domain.core.ioc.injector;

public class NoneInjector : IInjector
{
    public WorkoutQueryService WorkoutQueryService() => throw new NotImplementedException();

    public WorkoutCommand WorkoutCommand() => throw new NotImplementedException();
    public WorkoutQueryRepository WorkoutQueryRepository() => throw new NotImplementedException();
    public WorkoutRepository WorkoutRepository() => throw new NotImplementedException();
    public ExerciseRepository ExerciseRepository() => throw new NotImplementedException();
    public ExerciseQueryRepository ExerciseQueryRepository() => throw new NotImplementedException();
    public ExerciseQueryService ExerciseQueryService() => throw new NotImplementedException();
}