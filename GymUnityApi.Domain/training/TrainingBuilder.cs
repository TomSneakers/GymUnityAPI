using GymUnityApi.Domain.training.dto;

namespace GymUnityApi.Domain.training;

public class TrainingBuilder
{
    private string _name = string.Empty;
    private string _description = string.Empty;
    private IEnumerable<Exercice> _exercices = new List<Exercice>();
    private string _ownerId = "";

    public TrainingBuilder For(string userId)
    {
        _ownerId = userId;
        return this;
    }

    public TrainingBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public TrainingBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public TrainingBuilder WithExercices(IEnumerable<ExerciceDto> exercices)
    {
        _exercices = exercices.Select(exo => new Exercice(exo.Name));
        return this;
    }

    public Training Build() =>
        new(_ownerId, _name, _description,
            _exercices);
}