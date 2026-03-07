using Microsoft.EntityFrameworkCore;
using BIK.AuditService.Application.Interfaces;
using BIK.AuditService.Application.Services;
using BIK.AuditService.Infrastructure.Data;
using BIK.AuditService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AuditDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BIK.AuditService.Infrastructure.Data.AuditDbContext>();

    int retries = 0;
    while (retries < 10)
    {
        try
        {
            Console.WriteLine($"Intentando conectar a Auditoría (Intento {retries + 1}/10)...");
            context.Database.EnsureCreated();
            Console.WriteLine("Base de datos de Auditoría lista.");
            break;
        }
        catch (Exception)
        {
            retries++;
            if (retries >= 10) throw;
            Console.WriteLine("Postgres (Auditoría) no responde. Reintentando...");
            Thread.Sleep(3000);
        }
    }
}

app.Run();