using System;

namespace BIK.AuditService.Domain.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? AccountId { get; set; }
        public string? UserId { get; set; }
        public string Severity { get; set; } = "Info";
        public string SourceIpAddress { get; set; } = "127.0.0.1";
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}