using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("UserGroup", Schema = "Partograph")]
    public class UserGroupEntity
    {
        [ForeignKey("UserEntity")]
        public Guid UserId { get; set; }
        public required UserEntity User { get; set; }

        [ForeignKey("GroupEntity")]
        public int GroupId { get; set; }
        public required GroupEntity Group { get; set; }
    }
}
