using FluentAssertions;
using GymUnityApi.Domain.training.queryService;
using GymUnityApi.Domain.training.queryService.dto;
using Moq;
using NUnit.Framework;

namespace GymUnityApi.Tests.unit.training;

public class GetTrainingsServiceTest : BaseTest
{
    [Test]
    public void ShouldGetTrainings()
    {
        TrainingQueryRepositoryMock.Setup(tqr => tqr.GetTrainings(It.IsAny<string>()))
                                   .Returns(new List<TrainingPreview>
                                   {
                                       new()
                                       {
                                           Id = Guid.Parse("156cd177-be78-485a-a533-47791850a2fa"),
                                           Title = "Training 1",
                                           ExerciseCount = 2
                                       }
                                   });

        var result = new TrainingQueryService().GetTrainings("test");
        
        var firstTraining = result.First();
        TrainingQueryRepositoryMock.Verify(tqr => tqr.GetTrainings("test"), Times.Once);
        result.Count()
              .Should()
              .Be(1);
        firstTraining.Id.Should().Equals(Guid.Parse("156cd177-be78-485a-a533-47791850a2fa"));
        firstTraining.Title.Should().Be("Training 1");
        firstTraining.ExerciseCount.Should().Be(2);
    }
}