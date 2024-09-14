using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("PartographNotification", Schema = "Partograph")]
    public class PartographNotificationEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PartographEntity")]
        public Guid PartographId { get; set; }
        [ForeignKey("NotificationEntity")]
        public long NotificationId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Relaciones
        public PartographEntity? PartographEntity { get; set; }
        public NotificationEntity? NotificationEntity { get; set; }
    }
}
