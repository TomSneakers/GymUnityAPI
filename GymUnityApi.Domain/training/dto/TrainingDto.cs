namespace GymUnityApi.Domain.training.dto;

public class TrainingDto
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public IEnumerable<ExerciceDto> Exercices { get; set; } = new List<ExerciceDto>();
}

public class ExerciceDto
{
    public string Name { get; set; } = "";
}