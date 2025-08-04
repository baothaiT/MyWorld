using MyWorld.Domain.Entities.Enums;

namespace MyWorld.Domain.Entities;

public interface IEntity<T>
{
    T Id { get; set; }
}

public class BaseEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateAt { get; set; }
    public string CreatedBy { get; set; }
    public string UpdateBy { get; set; }
    public DataTypeEnum DataType { get; set; } = DataTypeEnum.None;
}