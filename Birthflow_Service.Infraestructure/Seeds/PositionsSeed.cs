using BirthflowService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirthflowService.Infraestructure.Seeds
{
    public class PositionsSeed : IEntityTypeConfiguration<PositionEntity>
    {
        public void Configure(EntityTypeBuilder<PositionEntity> builder)
        {
            builder.HasData(
             new PositionEntity { Code = " I", Id = 1, Description = "Plano I" },
             new PositionEntity { Code = "II", Id = 2, Description = "Plano II" },
             new PositionEntity { Code = "III", Id = 3, Description = "Plano III" },
             new PositionEntity { Code = "IV", Id = 4, Description = "Plano IV" }
            );
        }
    }
}
