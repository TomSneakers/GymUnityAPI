using GymUnityApi.Domain.core;

namespace GymUnityApi.Domain.training.repository;

public class TrainingRepository
{
    public void Save(Training training)
    {
        var statement = "INSERT INTO training (id, owner_id, title, description) VALUES ($1, $2, $3, $4)";
        new PgCommand().ExecuteNonQuery(statement,
            PgType.Guid(training.Id),
            PgType.String(training.OwnerId),
            PgType.String(training.Title),
            PgType.String(training.Description));

        SaveExercises(training);
    }

    private void SaveExercises(Training training)
    {
        foreach (var exercises in training.Exercises)
        {
            var statement = "INSERT INTO training_exercise (id, training_id, name) VALUES ($1, $2, $3)";
            new PgCommand().ExecuteNonQuery(statement,
                PgType.Guid(exercises.Id),
                PgType.Guid(training.Id),
                PgType.String(exercises.Name));
        }
    }
}