using BirthflowService.Domain.Entities;
using BirthflowService.Infraestructure.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Birthflow_Service.Infraestructure.DbContexts
{
    public class BirthflowDbContext : DbContext
    {
        public BirthflowDbContext(DbContextOptions<BirthflowDbContext> options) : base(options)
        {

        }

        //Autenticacion
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<PasswordEntity> Passwords { get; set; }
        public virtual DbSet<PasswordHistoryEntity> PasswordHistoryEntities { get; set; }
        public virtual DbSet<UserLoginAttemptEntity> UserLoginAttemptEntities { get; set; }
        public virtual DbSet<UserSessionHistoryEntity> UserSessionHistoryEntities { get; set; }
        public virtual DbSet<RefreshTokenEntity> RefreshTokenEntities { get; set; }
        public virtual DbSet<ActivationTokenEntity> ActivationTokenEntities { get; set; }

        //PARTOGRAPH
        public virtual DbSet<PartographEntity> Partographs { get; set; }
        public virtual DbSet<CervicalDilationEntity> CervicalDilations { get; set; }
        public virtual DbSet<MedicalSurveillanceTableEntity> MedicalSurveillanceTables { get; set; }
        public virtual DbSet<PresentationPositionVarietyEntity> PresentationPositionVarietyEntities { get; set; }
        public virtual DbSet<ChildbirthNoteEntity> ChildbirthNotes { get; set; }
        public virtual DbSet<ContractionFrequencyEntity> ContractionFrequencyEntities { get; set; }
        public virtual DbSet<FetalHeartRateEntity> FetalHeartRateEntities { get; set; }
        public virtual DbSet<PartographStateEntity> PartographStateEntities { get; set; }
        public virtual DbSet<PartographAuditLogEntity> PartographAuditLogs { get; set; }
        public virtual DbSet<PartographVersionEntity> PartographVersions { get; set; }

        //Catalogos
        public virtual DbSet<PositionEntity> PositionEntities { get; set; }
        public virtual DbSet<HodgePlanesEntity> HodgePlanesEntities { get; set; }
        public virtual DbSet<WorkTimeEntity> WorkTimeEntities { get; set; }
        public virtual DbSet<PermissionTypeEntity> PermissionTypeEntities { get; set; }

        //Notificaciones
        public virtual DbSet<NotificationTypeEntity> NotificationTypeEntities { get; set; }
        public virtual DbSet<NotificationEntity> NotificationEntities { get; set; }
        public virtual DbSet<UserNotificationEntity> UserNotificationEntities { get; set; }
        public virtual DbSet<PartographNotificationEntity> PartographNotificationEntities { get; set; }

        // Group - Compartir
        public virtual DbSet<GroupEntity> GroupEntities { get; set; }
        public virtual DbSet<UserGroupEntity> UserGroupsEntities { get; set; }
        public virtual DbSet<PartographGroupEntity> PartographGroupEntities { get; set; }
        public virtual DbSet<PartographGroupItemEntity> PartographGroupItemEntities { get; set; }
        public virtual DbSet<PartographGroupShareEntity> PartographGroupShareEntities { get; set; }
        public virtual DbSet<PartographShareEntity> PartographShareEntities { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new HodgePlanesSeed());
            builder.ApplyConfiguration(new PositionsSeed());
            builder.ApplyConfiguration(new WorkTimeSeed());
            builder.ApplyConfiguration(new PermissionTypeSeed());


            builder.Entity<UserGroupEntity>()
                .HasKey(ug => new { ug.UserId, ug.GroupId }); 
            builder.Entity<PartographGroupItemEntity>()
               .HasKey(ug => new { ug.PartographId, ug.PartographGroupId });

            base.OnModelCreating(builder);
        }
    }
}
