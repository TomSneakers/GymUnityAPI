namespace GymUnityApi.Domain.training;

public class Training
{
    public Guid Id { get; private set; }
    public string OwnerId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Exercice> Exercices { get; set; }
    
    public Training(string ownerId, string name, string description, IEnumerable<Exercice> exercices)
    {
        Id = Guid.NewGuid();
        OwnerId = ownerId;
        Name = name;
        Description = description;
        Exercices = exercices;
    }
}

public class Exercice
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    
    public Exercice(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}