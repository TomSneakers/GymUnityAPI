using GymUnityApi.Domain.training.dto;

namespace GymUnityApi.Domain.training;

public class TrainingCommand
{
    public void CreateTraining(string userId, string name, string description, IEnumerable<ExerciceDto> exercices)
    {
        var training = new TrainingBuilder().For(userId)
                                            .WithName(name)
                                            .WithDescription(description)
                                            .WithExercices(exercices)
                                            .Build();
        
        new TrainingRepository().Save(training);
    }
}