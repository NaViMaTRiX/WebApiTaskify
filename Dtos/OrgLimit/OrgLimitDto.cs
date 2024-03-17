﻿namespace WebApiTaskify.Dtos.OrgLimit;

public class OrgLimitDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrgId { get; set; } = Guid.Empty;
    public int Limit { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}