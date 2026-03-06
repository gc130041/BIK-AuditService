using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BIK.AuditService.Application.Interfaces;
using BIK.AuditService.Application.DTOs;

namespace BIK.AuditService.API.Controllers
{
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpPost("api/Audit")]
        [HttpPost("BIK/v1/Audit")]
        public async Task<IActionResult> CreateLog([FromBody] AuditLogDto logDto)
        {
            var result = await _auditLogService.LogActivityAsync(logDto);
            if (result) return Ok(new { message = "Log registrado exitosamente." });
            return BadRequest(new { message = "Error al registrar el log." });
        }

        [HttpGet("BIK/v1/accounts/{accountId}/history")]
        public async Task<IActionResult> GetAccountHistory(int accountId, [FromQuery] int limit = 100)
        {
            var history = await _auditLogService.GetAccountHistoryAsync(accountId, limit);
            return Ok(history);
        }

        [HttpGet("api/Audit")]
        [HttpGet("BIK/v1/Audit")]
        public async Task<IActionResult> GetGeneralHistory([FromQuery] int limit = 100)
        {
            var history = await _auditLogService.GetGeneralHistoryAsync(limit);
            return Ok(history);
        }
    }
}