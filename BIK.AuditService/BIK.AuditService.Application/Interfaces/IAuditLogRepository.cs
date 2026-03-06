using System.Collections.Generic;
using System.Threading.Tasks;
using BIK.AuditService.Domain.Entities;

namespace BIK.AuditService.Application.Interfaces
{
    public interface IAuditLogRepository
    {
        Task AddAsync(AuditLog log);
        Task<IEnumerable<AuditLog>> GetHistoryByAccountAsync(int accountId, int limit);
        Task<IEnumerable<AuditLog>> GetAllHistoryAsync(int limit);
        Task<bool> SaveChangesAsync();
    }
}