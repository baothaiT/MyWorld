using MyWorld.Domain.Enums;

namespace MyWorld.Domain.Entities;

public class VocabularyEntity : BaseEntity
{
    internal VocabularyEntity()
    {
    }   
    public VocabularyEntity(
        string key,
        string value,
        DataTypeEnum dataTypeEnum  = DataTypeEnum.None

    ) : base(
        id: Guid.NewGuid(),
        dataType: dataTypeEnum
        )
    {
        Key = key;
        Value = value;
    }

    public string Key { get; private set; } = string.Empty;
    public string Value { get; private set; } = string.Empty;
}

