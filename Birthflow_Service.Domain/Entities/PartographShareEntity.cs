using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BirthflowService.Domain.Entities
{
    [Table("PartographShare", Schema = "Partograph")]
    public class PartographShareEntity
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("PartographGroup")]
        public Guid PartographGroupId { get; set; }
        [ForeignKey("UserEntity")]
        public Guid? UserId { get; set; }
        [ForeignKey("GroupEntity")]
        public long? GroupId { get; set; }
        [ForeignKey("PermissionTypeEntity")]
        public int? PermissionTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public PartographEntity? PartographEntity { get; set; }
        public UserEntity? User { get; set; }
        public GroupEntity? GroupEntity { get; set; }
        public PermissionTypeEntity? AccessPermission { get; set; }
    }
}
