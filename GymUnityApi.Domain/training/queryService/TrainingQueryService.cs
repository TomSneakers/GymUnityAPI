using GymUnityApi.Domain.training.queryService.dto;

namespace GymUnityApi.Domain.training.queryService;

public class TrainingQueryService
{
    public IEnumerable<TrainingPreview> GetTrainings(string accountId)
    {
        return TrainingQueryRepository.GetTrainings(accountId);
    }
}