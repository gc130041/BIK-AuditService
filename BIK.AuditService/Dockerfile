FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["BIK.AuditService.API/BIK.AuditService.API.csproj", "BIK.AuditService.API/"]
COPY ["BIK.AuditService.Application/BIK.AuditService.Application.csproj", "BIK.AuditService.Application/"]
COPY ["BIK.AuditService.Domain/BIK.AuditService.Domain.csproj", "BIK.AuditService.Domain/"]
COPY ["BIK.AuditService.Infrastructure/BIK.AuditService.Infrastructure.csproj", "BIK.AuditService.Infrastructure/"]
RUN dotnet restore "BIK.AuditService.API/BIK.AuditService.API.csproj"

COPY . .
WORKDIR "/src/BIK.AuditService.API"
RUN dotnet build "BIK.AuditService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BIK.AuditService.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BIK.AuditService.API.dll"]