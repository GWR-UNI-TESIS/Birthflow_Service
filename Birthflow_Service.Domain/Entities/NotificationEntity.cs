using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.Entities
{
    [Table("Notification", Schema = "Notification")]
    public class NotificationEntity
    {
        [Key]
        public long NotificationId { get; set; }
        public Guid Identificator {  get; set; }
        public required string Title { get; set; }
        public required string Message { get; set; }
        [ForeignKey("NotificationTypeEntity")]
        public int Type { get; set; }
        public DateTime ScheduledFor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public virtual NotificationTypeEntity? NotificationType { get; set; } 
    }
}
