using GymUnityApi.Domain.core;
using GymUnityApi.Domain.workout.queryService.dto;

namespace GymUnityApi.Domain.workout.queryService;

public class WorkoutQueryRepository
{
    public IEnumerable<PgConverter> GetWorkouts(string accountId)
    {
        var statement = @"SELECT id,
                                 title,
                                 description
                          FROM workout 
                          WHERE owner_id = $1;";
        return new PgCommand().ExecuteDataTable(statement, PgType.ToString(accountId));
    }
}