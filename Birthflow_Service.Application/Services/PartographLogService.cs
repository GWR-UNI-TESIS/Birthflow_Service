using AutoMapper;
using BirthflowService.Application.Interfaces;
using BirthflowService.Application.Utils;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using BirthflowService.Domain.Models.Log;
using Newtonsoft.Json;

namespace BirthflowService.Application.Services
{
    public class PartographLogService : IPartographLogService
    {

        private readonly IPartographLogRepository _logRepository;
        private readonly IMapper _mapper;
        private readonly ICurvesGenerator _curvesGenerator;
        private readonly PartographAuditLogGenerator _logGenerator;
        public PartographLogService(IPartographLogRepository logRepository, IMapper mapper, ICurvesGenerator curvesGenerator)
        {
            _logRepository = logRepository;
            _mapper = mapper;
            _curvesGenerator = curvesGenerator;
            _logGenerator = new PartographAuditLogGenerator();
        }

        public async Task SaveLog<T>(T newEntity, PartographEntity partographEntity, Guid userId)
        {
            GlobalPartographLog globalPartographLog = _mapper.Map<GlobalPartographLog>(partographEntity);

            globalPartographLog.curves = _curvesGenerator.GenerateCurves(partographEntity);

            var partographVersion = new PartographVersionEntity
            {
                PartographId = partographEntity.PartographId,
                ChangedAt = DateTime.UtcNow,
                ChangedBy = userId,
                PartographDataJson = JsonConvert.SerializeObject(globalPartographLog)
            };

            var resultPartographVersion = await _logRepository.CreatePartographVersion(partographVersion);

            var auditLogs = _logGenerator.LogNewEntity(newEntity, partographEntity.PartographId, userId, resultPartographVersion.Id);

            // Guardar los logs de auditoría si hay cambios
            if (auditLogs.Any())
            {
                await _logRepository.CreateAuditLogs(auditLogs);
            }
        }

        public async Task SaveLog<T>(T newEntity, T oldEntity, PartographEntity partographEntity, Guid userId)
        {
            //Guardar el cambio de informacion en historico

            GlobalPartographLog globalPartographLog = _mapper.Map<GlobalPartographLog>(partographEntity);

            globalPartographLog.curves = _curvesGenerator.GenerateCurves(partographEntity);

            var partographVersion = new PartographVersionEntity
            {
                PartographId = partographEntity.PartographId,
                ChangedAt = DateTime.UtcNow,
                ChangedBy = userId,
                PartographDataJson = JsonConvert.SerializeObject(globalPartographLog)
            };

            var savePartographVersion = await _logRepository.CreatePartographVersion(partographVersion);

            var auditLogs = _logGenerator.CompareEntities(oldEntity, newEntity, partographEntity.PartographId, userId, savePartographVersion.Id);

            // Guardar los logs de auditoría si hay cambios
            if (auditLogs.Any())
            {
                await _logRepository.CreateAuditLogs(auditLogs);
            }
        }
    }
}
