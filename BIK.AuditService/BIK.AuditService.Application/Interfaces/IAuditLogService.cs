using System.Collections.Generic;
using System.Threading.Tasks;
using BIK.AuditService.Application.DTOs;
using BIK.AuditService.Domain.Entities;

namespace BIK.AuditService.Application.Interfaces
{
    public interface IAuditLogService
    {
        Task<bool> LogActivityAsync(AuditLogDto logDto);
        Task<IEnumerable<AuditLog>> GetAccountHistoryAsync(int accountId, int limit = 100);
        Task<IEnumerable<AuditLog>> GetGeneralHistoryAsync(int limit = 100);
    }
}