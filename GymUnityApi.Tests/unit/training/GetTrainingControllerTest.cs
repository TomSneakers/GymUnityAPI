using FluentAssertions;
using GymUnityAPI.controller.training;
using Moq;
using NUnit.Framework;

namespace GymUnityApi.Tests.unit.training;

public class GetTrainingControllerTest : BaseTest
{
    [Test]
    public void ShouldGetTrainings()
    {
        var result = new TrainingController().GetTrainings();

        result.StatusCode.Should()
              .Be(200);
        TrainingQueryServiceMock.Verify(tqs => tqs.GetTrainings(It.IsAny<string>()), Times.Once);
    }
}