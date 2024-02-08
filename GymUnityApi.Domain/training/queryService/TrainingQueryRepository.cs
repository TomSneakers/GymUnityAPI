using GymUnityApi.Domain.core;
using GymUnityApi.Domain.training.queryService.dto;

namespace GymUnityApi.Domain.training.queryService;

public class TrainingQueryRepository
{
    public static IEnumerable<TrainingPreview> GetTrainings(string accountId)
    {
        var statement = "SELECT t.id, t.name, COUNT(te.id) FROM training t JOIN training_exercise te ON t.id = te.training_id WHERE t.account_id = $1 GROUP BY t.id, t.name";
        var result = new PgCommand().ExecuteDataTable(statement, PgType.String(accountId));
        return result.Select(convert => new TrainingPreview
        {
            Id = convert.ToGuid(0),
            Name = convert.ToString(1),
            ExerciseCount = convert.ToInt(2)
        });
    }
}