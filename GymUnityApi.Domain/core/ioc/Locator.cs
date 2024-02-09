using GymUnityApi.Domain.core.ioc.injector;
using GymUnityApi.Domain.training;
using GymUnityApi.Domain.training.queryService;
using GymUnityApi.Domain.training.repository;

namespace GymUnityApi.Domain.core.ioc;

public static class Locator
{
    private static IInjector _injector = new NoneInjector();

    public static void Load(IInjector injector)
    {
        _injector = injector;
    }

    public static TrainingQueryService TrainingQueryService() => _injector.TrainingQueryService();
    public static TrainingCommand TrainingCommand() => _injector.TrainingCommand();
    public static TrainingQueryRepository TrainingQueryRepository() => _injector.TrainingQueryRepository();
    public static TrainingRepository TrainingRepository() => _injector.TrainingRepository();
}