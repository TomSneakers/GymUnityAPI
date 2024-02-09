using GymUnityApi.Domain.exercise.queryService;
using GymUnityApi.Domain.exercise.queryService.queryRepository;
using GymUnityApi.Domain.exercise.repository;
using GymUnityApi.Domain.workout;
using GymUnityApi.Domain.workout.queryService;
using GymUnityApi.Domain.workout.repository;

namespace GymUnityApi.Domain.core.ioc.injector;

public interface IInjector
{
    WorkoutQueryService WorkoutQueryService();
    WorkoutCommand WorkoutCommand();
    WorkoutQueryRepository WorkoutQueryRepository();
    WorkoutRepository WorkoutRepository();
    ExerciseRepository ExerciseRepository();
    ExerciseQueryRepository ExerciseQueryRepository();
    ExerciseQueryService ExerciseQueryService();
}