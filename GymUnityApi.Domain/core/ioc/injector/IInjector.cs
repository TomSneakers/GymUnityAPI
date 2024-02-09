using GymUnityApi.Domain.training;
using GymUnityApi.Domain.training.queryService;
using GymUnityApi.Domain.training.repository;

namespace GymUnityApi.Domain.core.ioc.injector;

public interface IInjector
{
    TrainingQueryService TrainingQueryService();
    TrainingCommand TrainingCommand();
    TrainingQueryRepository TrainingQueryRepository();
    TrainingRepository TrainingRepository();
}