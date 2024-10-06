using BirthflowService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirthflowService.Infraestructure.Seeds
{
    public class WorkTimeItemSeed : IEntityTypeConfiguration<WorkTimeItemEntity>
    {
        public void Configure(EntityTypeBuilder<WorkTimeItemEntity> builder)
        {
            builder.HasData(
                new WorkTimeItemEntity {Id = 1,  WorkTimeId = "VTI", CervicalDilation = 6, Time = new TimeSpan(2, 10, 0)},
                new WorkTimeItemEntity {Id = 2, WorkTimeId = "VTI", CervicalDilation = 7, Time = new TimeSpan(1, 15, 0) },
                new WorkTimeItemEntity {Id = 3, WorkTimeId = "VTI", CervicalDilation = 8, Time = new TimeSpan(1, 0, 0) },
                new WorkTimeItemEntity {Id = 4, WorkTimeId = "VTI", CervicalDilation = 9, Time = new TimeSpan(0, 35, 0) },
                new WorkTimeItemEntity {Id = 5, WorkTimeId = "VTI", CervicalDilation = 10, Time = new TimeSpan(0, 25, 0) },
                new WorkTimeItemEntity {Id = 6, WorkTimeId = "VTI", CervicalDilation = 11, Time = new TimeSpan(0, 15, 0) },
                                        
                new WorkTimeItemEntity {Id = 7, WorkTimeId = "HMI", CervicalDilation = 6, Time = new TimeSpan(2, 30, 0) },
                new WorkTimeItemEntity {Id = 8, WorkTimeId = "HMI", CervicalDilation = 7, Time = new TimeSpan(1, 25, 0) },
                new WorkTimeItemEntity {Id = 9, WorkTimeId = "HMI", CervicalDilation = 8, Time = new TimeSpan(0, 55, 0) },
                new WorkTimeItemEntity {Id = 10, WorkTimeId = "HMI", CervicalDilation = 9, Time = new TimeSpan(0, 40, 0) },
                new WorkTimeItemEntity {Id = 11, WorkTimeId = "HMI", CervicalDilation = 10, Time = new TimeSpan(0, 25, 0) },
                new WorkTimeItemEntity {Id = 12, WorkTimeId = "HMI", CervicalDilation = 11, Time = new TimeSpan(0, 15, 0) },
                                      
                new WorkTimeItemEntity {Id = 13, WorkTimeId = "HMR", CervicalDilation = 6, Time = new TimeSpan(2, 30, 0) },
                new WorkTimeItemEntity {Id = 14, WorkTimeId = "HMR", CervicalDilation = 7, Time = new TimeSpan(1, 05, 0) },
                new WorkTimeItemEntity {Id = 15, WorkTimeId = "HMR", CervicalDilation = 8, Time = new TimeSpan(0, 35, 0) },
                new WorkTimeItemEntity {Id = 16, WorkTimeId = "HMR", CervicalDilation = 9, Time = new TimeSpan(0, 25, 0) },
                new WorkTimeItemEntity {Id = 17, WorkTimeId = "HMR", CervicalDilation = 10, Time = new TimeSpan(0, 10, 0) },
                new WorkTimeItemEntity {Id = 18, WorkTimeId = "HMR", CervicalDilation = 11, Time = new TimeSpan(0, 05, 0) },
                                        
                new WorkTimeItemEntity {Id = 19, WorkTimeId = "HNI", CervicalDilation = 6, Time = new TimeSpan(3, 15, 0) },
                new WorkTimeItemEntity {Id = 20, WorkTimeId = "HNI", CervicalDilation = 7, Time = new TimeSpan(1, 30, 0) },
                new WorkTimeItemEntity {Id = 21, WorkTimeId = "HNI", CervicalDilation = 8, Time = new TimeSpan(1, 00, 0) },
                new WorkTimeItemEntity {Id = 22, WorkTimeId = "HNI", CervicalDilation = 9, Time = new TimeSpan(0, 40, 0) },
                new WorkTimeItemEntity {Id = 23, WorkTimeId = "HNI", CervicalDilation = 10, Time = new TimeSpan(0, 35, 0) },
                new WorkTimeItemEntity {Id = 24, WorkTimeId = "HNI", CervicalDilation = 11, Time = new TimeSpan(0, 30, 0) },
                                        
                new WorkTimeItemEntity {Id = 25, WorkTimeId = "HNR", CervicalDilation = 6, Time = new TimeSpan(2, 30, 0) },
                new WorkTimeItemEntity {Id = 26, WorkTimeId = "HNR", CervicalDilation = 7, Time = new TimeSpan(1, 25, 0) },
                new WorkTimeItemEntity {Id = 27, WorkTimeId = "HNR", CervicalDilation = 8, Time = new TimeSpan(1, 05, 0) },
                new WorkTimeItemEntity {Id = 28, WorkTimeId = "HNR", CervicalDilation = 9, Time = new TimeSpan(0, 50, 0) },
                new WorkTimeItemEntity {Id = 29, WorkTimeId = "HNR", CervicalDilation = 10, Time = new TimeSpan(0, 35, 0) },
                new WorkTimeItemEntity {Id = 30, WorkTimeId = "HNR", CervicalDilation = 11, Time = new TimeSpan(0, 20, 0) }
            );
        }
    }
}
