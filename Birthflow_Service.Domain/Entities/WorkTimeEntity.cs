using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("WorkTime", Schema = "Partograph")]
    public class WorkTimeEntity
    {
        [MaxLength(3), Key]
        public required string Id { get; set; }
        public required string Paridad { get; set; }
        public required string Posicion { get; set; }
        public required string Membrana { get; set; }
        public virtual ICollection<WorkTimeItemEntity> WorkTimeItems { get; set; } = new List<WorkTimeItemEntity>();
    }
}
