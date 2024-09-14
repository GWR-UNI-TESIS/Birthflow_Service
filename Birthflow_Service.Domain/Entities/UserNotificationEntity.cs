using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BirthflowService.Domain.Entities
{
    [Table("UserNotification", Schema = "Notification")]
    public class UserNotificationEntity
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("UserEntity")]
        public Guid UserId { get; set; }
        [ForeignKey("NotificationEntity")]
        public long NotificationId { get; set; }
        [ForeignKey("GroupEntity")]
        public long? GroupId { get; set; }
        public bool Viewed { get; set; }
        public bool Read { get; set; }
        public bool Delivered { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ViewedAt { get; set; }
        public DateTime? ReadAt { get; set; }


        public virtual UserEntity? UserEntity { get; set; }
        public virtual GroupEntity? GroupEntity { get; set; }
        public NotificationEntity? NotificationEntity { get; set; }
    }
}
