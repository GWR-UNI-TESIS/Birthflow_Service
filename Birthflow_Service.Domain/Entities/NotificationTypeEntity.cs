using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("NotificationType", Schema = "Notification")]
    public class NotificationTypeEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
