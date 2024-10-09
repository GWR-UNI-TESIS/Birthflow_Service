using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("PartographState", Schema = "Partograph")]
    public class PartographStateEntity
    {
        [Key]
        public long Id { get; set; }
        [Required, ForeignKey("PartographEntity")]
        public Guid PartographId { get; set; }
        [Required, ForeignKey("UserEntity")]
        public Guid UserId { get; set; }
        public bool IsAchived { get; set; }
        public bool Set {  get; set; }
        public bool Silenced { get; set; }
        public bool Favorite { get; set; }

        public virtual PartographEntity? PartographEntity { get; set; }
        public virtual UserEntity? UserEntity { get; set; }
    }
}
