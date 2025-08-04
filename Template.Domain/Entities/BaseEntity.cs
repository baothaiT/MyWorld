using System;

namespace Template.Domain.Entities;

public class BaseEntity
{
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateAt { get; set; }
    public string CreatedBy { get; set; }
    public string UpdateBy { get; set; }
}
