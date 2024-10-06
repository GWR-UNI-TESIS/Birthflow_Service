using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("WorkTimeItem", Schema = "Partograph")]
    public class WorkTimeItemEntity
    {
        public int Id { get; set; }
        [MaxLength(3), ForeignKey("WorkTimeEntity")]
        public required string WorkTimeId { get; set; }
        public required double CervicalDilation { get; set; }
        public required TimeSpan Time { get; set; }

        public WorkTimeEntity? WorkTimeEntity { get; set; }
    }
}
