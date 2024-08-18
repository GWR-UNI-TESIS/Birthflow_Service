using BirthflowService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Infraestructure.Seeds
{
    public class WorkTimeSeed : IEntityTypeConfiguration<WorkTimeEntity>
    {
        public void Configure(EntityTypeBuilder<WorkTimeEntity> builder)
        {
            builder.HasData(
                new WorkTimeEntity {  Id = "VTI", Posicion = "Vertical", Paridad = "Todas", Membrana ="Integras" },
                new WorkTimeEntity { Id = "HMI", Posicion = "Horizontal", Paridad = "Multiparas", Membrana = "Integras" },
                new WorkTimeEntity { Id = "HMR", Posicion = "Horizontal", Paridad = "Multiparas", Membrana = "Rotas" },
                new WorkTimeEntity { Id = "HNI", Posicion = "Horizontal", Paridad = "Nuliparas", Membrana = "Integras" },
                new WorkTimeEntity { Id = "HNR", Posicion = "Horizontal", Paridad = "Nuliparas", Membrana = "Rotas" }

            );
        }
    }
}
