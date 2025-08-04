namespace MyWorld.Domain.Entities;

public class VocabularyEntity
{
    public Guid Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

