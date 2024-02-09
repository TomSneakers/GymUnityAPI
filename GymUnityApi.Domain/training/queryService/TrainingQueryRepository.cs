using GymUnityApi.Domain.core;
using GymUnityApi.Domain.training.queryService.dto;

namespace GymUnityApi.Domain.training.queryService;

public class TrainingQueryRepository
{
    public IEnumerable<TrainingPreview> GetTrainings(string accountId)
    {
        var statement = @"SELECT t.id, 
                                 t.title, 
                                 COUNT(te.id)
                          FROM training t 
                          LEFT JOIN training_exercise te ON t.id = te.training_id 
                          WHERE t.owner_id = $1 
                          GROUP BY t.id, t.title;";
        var result = new PgCommand().ExecuteDataTable(statement, PgType.String(accountId));
        return result.Select(convert => new TrainingPreview
        {
            Id = convert.ToGuid(0),
            Title = convert.ToString(1),
            ExerciseCount = convert.ToInt(2)
        });
    }
}