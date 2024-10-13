using BirthflowService.Domain.Entities;

namespace BirthflowService.Application.Utils
{
    public  class PartographAuditLogGenerator
    {
        public List<PartographAuditLogEntity> CompareEntities<T>(T oldEntity, T newEntity, Guid partographId, Guid userId, int partographVersionId, List<string> excludedProperties = null)
        {
            var auditLogs = new List<PartographAuditLogEntity>();

            // Obtenemos todas las propiedades públicas del tipo T
            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                // Omitir propiedades excluidas
                if (excludedProperties != null && excludedProperties.Contains(prop.Name))
                {
                    continue;
                }

                // Obtenemos los valores antiguos y nuevos
                var oldValue = prop.GetValue(oldEntity)?.ToString() ?? "null";
                var newValue = prop.GetValue(newEntity)?.ToString() ?? "null";

                // Si los valores son diferentes, creamos un log de auditoría
                if (oldValue != newValue)
                {
                    auditLogs.Add(new PartographAuditLogEntity
                    {
                        PartographId = partographId,
                        EntityName = typeof(T).Name,  // Nombre de la entidad (ej. "CervicalDilationEntity")
                        FieldName = prop.Name,        // Nombre del campo
                        OldValue = oldValue,          // Valor antiguo
                        NewValue = newValue,          // Nuevo valor
                        ChangedAt = DateTime.UtcNow,
                        ChangedBy = userId,
                        PartographVersionId = partographVersionId,
                    });
                }
            }

            return auditLogs;
        }

        public List<PartographAuditLogEntity> LogNewEntity<T>(T newEntity, Guid partographId, Guid userId, int partographVersionId)
        {
            var auditLogs = new List<PartographAuditLogEntity>();

            foreach (var property in newEntity!.GetType().GetProperties())
            {
                var newValue = property.GetValue(newEntity)?.ToString();

                var auditLog = new PartographAuditLogEntity
                {
                    PartographId = partographId,
                    EntityName = newEntity.GetType().Name,  // El nombre de la entidad
                    FieldName = property.Name,  // El nombre del campo que fue creado
                    OldValue = "N/A",  // No había valor anterior
                    NewValue = newValue ?? "N/A",  // Valor recién creado
                    ChangedAt = DateTime.UtcNow,
                    ChangedBy = userId,
                    PartographVersionId = partographVersionId
                };

                auditLogs.Add(auditLog);
            }

            return auditLogs;
        }
    }
}
