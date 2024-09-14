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
    public class PermissionTypeSeed: IEntityTypeConfiguration<PermissionTypeEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionTypeEntity> builder)
        {
            builder.HasData(
                new PermissionTypeEntity { Id = 1, Identificator= Guid.NewGuid(), Name = "Lectura", Description = "Permisos de lectura", CreateAt = DateTime.Now},
                new PermissionTypeEntity { Id = 2, Identificator = Guid.NewGuid(), Name = "Escritura", Description = "Permisos de escritura", CreateAt = DateTime.Now },
                new PermissionTypeEntity { Id = 3, Identificator = Guid.NewGuid(), Name = "Lectura y Escritura", Description = "Permisos de lectura y escritura", CreateAt = DateTime.Now }
            );
        }
    }
}

