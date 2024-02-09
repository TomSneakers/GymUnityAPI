using GymUnityApi.Domain.training;
using GymUnityApi.Domain.training.queryService;
using GymUnityApi.Domain.training.repository;

namespace GymUnityApi.Domain.core.ioc.injector;

public class NoneInjector : IInjector
{
    public TrainingQueryService TrainingQueryService() => throw new NotImplementedException();

    public TrainingCommand TrainingCommand() => throw new NotImplementedException();
    public TrainingQueryRepository TrainingQueryRepository() => throw new NotImplementedException();
    public TrainingRepository TrainingRepository() => throw new NotImplementedException();
}