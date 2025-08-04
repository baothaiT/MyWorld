using MyWorld.Domain.Enums;

namespace MyWorld.Domain.Entities;


public class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        CreatedBy = "System";
        DataType = DataTypeEnum.None;
    }
    public BaseEntity(
        Guid id,
        DataTypeEnum dataType = DataTypeEnum.None,
        string createdBy = "System",
        DateTime? createdAt = null
    )
    {
        Id = Guid.Empty == id ? Guid.NewGuid() : id;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        CreatedBy = createdBy;
        DataType = dataType;
    }
    public Guid Id { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdateAt { get; private set; }
    public string CreatedBy { get; private set; }
    public string? UpdateBy { get; private set; }
    public DataTypeEnum DataType { get; private set; }
}