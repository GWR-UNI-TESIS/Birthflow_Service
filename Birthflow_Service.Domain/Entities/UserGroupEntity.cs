using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("UserGroup", Schema = "Partograph")]
    public class UserGroupEntity
    {
        [ForeignKey("UserEntity")]
        public Guid UserId { get; set; }
        public required UserEntity UserEntity { get; set; }

        [ForeignKey("GroupEntity")]
        public long GroupId { get; set; }
        public required GroupEntity GroupEntity { get; set; }
    }
}
