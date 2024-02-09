using GymUnityApi.Domain.training;
using GymUnityApi.Domain.training.queryService;
using GymUnityApi.Domain.training.repository;

namespace GymUnityApi.Domain.core.ioc.injector;

public class ProdInjector : IInjector
{
    public TrainingQueryService TrainingQueryService() => new();
    public TrainingCommand TrainingCommand() => new ();
    public TrainingQueryRepository TrainingQueryRepository() => new();
    public TrainingRepository TrainingRepository() => new();
}