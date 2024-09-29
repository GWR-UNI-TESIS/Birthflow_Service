using AutoMapper;
using Birthflow_Application.DTOs.Auth;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.DTOs.Share;
using BirthflowService.Domain.Entities;

namespace BirthflowService.Application.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, UserEntity>()
                .ForMember(dest => dest.IsActive, opt => opt.Ignore()) // Ignorar campos no mapeables
                .ForMember(dest => dest.IsDelete, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Passwords, opt => opt.Ignore()) // Ignorar las colecciones
                .ForMember(dest => dest.PartographStateEntity, opt => opt.Ignore())
                .ForMember(dest => dest.UserGroupEntity, opt => opt.Ignore())
                .ForMember(dest => dest.PartographShareEntity, opt => opt.Ignore())
                .ForMember(dest => dest.PartographGroupShares, opt => opt.Ignore())
                .ForMember(dest => dest.UserNotificationEntity, opt => opt.Ignore());

            // Mapeo inverso de UserEntity a UserDto
            CreateMap<UserEntity, UserDto>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<PartographDto, PartographEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PartographEntity, PartographDto>();

            CreateMap<CervicalDilationDto, CervicalDilationEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CervicalDilationEntity, CervicalDilationDto>();

            CreateMap<MedicalSurveillanceTableDto, MedicalSurveillanceTableEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<MedicalSurveillanceTableEntity, MedicalSurveillanceTableDto>();
            
            CreateMap<PresentationPositionVarietyDto, PresentationPositionVarietyEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PresentationPositionVarietyEntity, PresentationPositionVarietyDto>();

            CreateMap<FetalHeartRateDto, FetalHeartRateEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<FetalHeartRateEntity, FetalHeartRateDto>();

            CreateMap<ContractionFrequencyDto, ContractionFrequencyEntity>()
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ContractionFrequencyEntity, ContractionFrequencyDto>();

            CreateMap<ChildbirthNoteDto, ChildbirthNoteEntity>()
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ChildbirthNoteEntity, ChildbirthNoteDto>();


            //SHARE Metodos

            CreateMap<GroupDto, GroupEntity>()
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<GroupEntity, GroupDto>();
        }
    }
}
