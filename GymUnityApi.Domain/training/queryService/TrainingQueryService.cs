using GymUnityApi.Domain.core.ioc;
using GymUnityApi.Domain.training.queryService.dto;

namespace GymUnityApi.Domain.training.queryService;

public class TrainingQueryService
{
    public IEnumerable<TrainingPreview> GetTrainings(string accountId)
    {
        var trainingPreviews = Locator.TrainingQueryRepository().GetTrainings(accountId);
        return trainingPreviews;
    }
}