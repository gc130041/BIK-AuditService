using System.Collections.Generic;
using System.Threading.Tasks;
using BIK.AuditService.Application.DTOs;
using BIK.AuditService.Application.Interfaces;
using BIK.AuditService.Domain.Entities;

namespace BIK.AuditService.Application.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _repository;

        public AuditLogService(IAuditLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> LogActivityAsync(AuditLogDto logDto)
        {
            var log = new AuditLog
            {
                ActionType = logDto.ActionType,
                Description = logDto.Description,
                AccountId = logDto.AccountId,
                UserId = logDto.UserId,
                Severity = logDto.Severity,
                SourceIpAddress = logDto.SourceIpAddress
            };

            await _repository.AddAsync(log);
            return await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetAccountHistoryAsync(int accountId, int limit = 100)
        {
            return await _repository.GetHistoryByAccountAsync(accountId, limit);
        }

        public async Task<IEnumerable<AuditLog>> GetGeneralHistoryAsync(int limit = 100)
        {
            return await _repository.GetAllHistoryAsync(limit);
        }
    }
}