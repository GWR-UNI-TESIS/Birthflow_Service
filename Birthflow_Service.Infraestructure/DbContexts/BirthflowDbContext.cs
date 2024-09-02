using BirthflowMicroServices.Domain.Models;
using BirthflowService.Domain.Entities;
using BirthflowService.Infraestructure.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Service.Infraestructure.DbContexts
{
    public class BirthflowDbContext : DbContext
    {
        public BirthflowDbContext(DbContextOptions<BirthflowDbContext> options) : base(options)
        {

        }

        // AUTH
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<PasswordEntity> Passwords { get; set; }
        //PARTOGRAPH
        public virtual DbSet<PartographEntity> Partographs { get; set; }
        public virtual DbSet<CervicalDilationEntity> CervicalDilations { get; set; }
        public virtual DbSet<MedicalSurveillanceTableEntity> MedicalSurveillanceTables { get; set; }
        public virtual DbSet<PresentationPositionVarietyEntity> PresentationPositionVarietyEntities { get; set; }
        public virtual DbSet<ChildbirthNoteEntity> ChildbirthNotes { get; set; }
        public virtual DbSet<ContractionFrequencyEntity> ContractionFrequencyEntities { get; set; }
        public virtual DbSet<FetalHeartRateEntity> FetalHeartRateEntities { get; set; }
        public virtual DbSet<PositionEntity> PositionEntities { get; set; }
        public virtual DbSet<HodgePlanesEntity> HodgePlanesEntities { get; set; }
        public virtual DbSet<WorkTimeEntity> WorkTimeEntities { get; set; }
        public virtual DbSet<RefreshTokenEntity> RefreshTokenEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new HodgePlanesSeed());
            builder.ApplyConfiguration(new PositionsSeed());
            builder.ApplyConfiguration(new WorkTimeSeed());

            base.OnModelCreating(builder);
        }
    }
}
