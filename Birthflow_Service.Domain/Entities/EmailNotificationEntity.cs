using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("EmailNotification", Schema = "Notification")]
    public class EmailNotificationEntity
    {
        [Key]
        public long Id { get; set; }
        public int UserNotificationId { get; set; }
        public string Email { get; set; } = null!;
        public string State { get; set; } = null!;
        public DateTime? DateSent { get; set; }
        public int AttemptsSent { get; set; }
        public string ErrorMessage { get; set; } = null!;

        public UserNotificationEntity? UserNotificationEntity { get; set; }
    }
}
