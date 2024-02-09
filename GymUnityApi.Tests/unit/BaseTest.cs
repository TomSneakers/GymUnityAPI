using GymUnityApi.Domain.core.ioc;
using GymUnityApi.Domain.core.ioc.injector;
using GymUnityApi.Domain.training;
using GymUnityApi.Domain.training.queryService;
using GymUnityApi.Domain.training.repository;
using GymUnityApi.Tests.unit.training;
using Moq;
using NUnit.Framework;

namespace GymUnityApi.Tests.unit;

public class BaseTest
{
    private TestInjector _injector = new();
    protected Mock<TrainingQueryService> TrainingQueryServiceMock => _injector.trainingQueryService;
    protected Mock<TrainingQueryRepository> TrainingQueryRepositoryMock => _injector.trainingQueryRepository;
    protected Mock<TrainingRepository> TrainingRepositoryMock => _injector.trainingRepository;
    protected Mock<TrainingCommand> TrainingCommandMock => _injector.trainingCommand;
    
    [SetUp]
    public void Setup()
    {
        Locator.Load(_injector);
    }
}

public class TestInjector : IInjector
{
    public Mock<TrainingQueryRepository> trainingQueryRepository = new(){CallBase = false};
    public Mock<TrainingRepository> trainingRepository = new(){CallBase = false};
    public Mock<TrainingCommand> trainingCommand = new(){CallBase = false};
    public Mock<TrainingQueryService> trainingQueryService = new(){CallBase = false};
    
    public TrainingQueryService TrainingQueryService() => trainingQueryService.Object;
    public TrainingCommand TrainingCommand() => trainingCommand.Object;
    public TrainingQueryRepository TrainingQueryRepository() => trainingQueryRepository.Object;
    public TrainingRepository TrainingRepository() => trainingRepository.Object;
}