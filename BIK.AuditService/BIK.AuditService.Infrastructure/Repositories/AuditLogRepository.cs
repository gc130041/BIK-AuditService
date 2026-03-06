using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BIK.AuditService.Application.Interfaces;
using BIK.AuditService.Domain.Entities;
using BIK.AuditService.Infrastructure.Data;

namespace BIK.AuditService.Infrastructure.Repositories
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly AuditDbContext _context;

        public AuditLogRepository(AuditDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AuditLog log)
        {
            await _context.AuditLogs.AddAsync(log);
        }

        public async Task<IEnumerable<AuditLog>> GetHistoryByAccountAsync(int accountId, int limit)
        {
            return await _context.AuditLogs
                .Where(log => log.AccountId == accountId)
                .OrderByDescending(log => log.Timestamp)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetAllHistoryAsync(int limit)
        {
            return await _context.AuditLogs
                .OrderByDescending(log => log.Timestamp)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}