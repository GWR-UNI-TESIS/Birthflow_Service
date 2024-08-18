using BirthflowService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirthflowService.Infraestructure.Seeds
{
    public class HodgePlanesSeed : IEntityTypeConfiguration<HodgePlanesEntity>
    {
        public void Configure(EntityTypeBuilder<HodgePlanesEntity> builder)
        {
            builder.HasData(
                new HodgePlanesEntity { Code = "OP", Id = 1, Description = "Occipito Posterior" },
                new HodgePlanesEntity { Code = "OIIA", Id = 2, Description = "Occipito Izquierda Anterior" },
                new HodgePlanesEntity { Code = "OIIT", Id = 3, Description = "Occipito Izquierda Transversa" },
                new HodgePlanesEntity { Code = "OIIP", Id = 4, Description = "Occipito Izquierda Posterior" },
                new HodgePlanesEntity { Code = "OS", Id = 5, Description = "Occipito Sacro" },
                new HodgePlanesEntity { Code = "OIDA", Id = 6, Description = "Occipito Derecha Anterior" },
                new HodgePlanesEntity { Code = "OIDT", Id = 7, Description = "Occipito Derecha Transversa" },
                new HodgePlanesEntity { Code = "OIDP", Id = 8, Description = "Occipito Derecha Posterior" }
            );
        }
    }
}