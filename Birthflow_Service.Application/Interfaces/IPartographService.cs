using Birthflow_Application.DTOs;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Application.Interfaces
{
    public interface IPartographService
    {
        BaseResponse<IEnumerable<PartographEntity>> GetPartographs(Guid userId);
        BaseResponse<PartographEntity> GetPartograph(Guid partographId);
        BaseResponse<PartographEntity> CreatePartograph(PartographDto partographDto);

        // Dilatacion Cervical
        BaseResponse<CervicalDilationEntity> CreateCervicalDilation(CervicalDilationDto cervicalDilationDto);
        BaseResponse<CervicalDilationEntity> UpdateCervicalDilation(CervicalDilationDto cervicalDilationDto);
        BaseResponse<CervicalDilationEntity> DeleteCervicalDilation(CervicalDilationDto cervicalDilationDto);
        BaseResponse<IEnumerable<CervicalDilationEntity>> GetCervicalDilations(Guid partographId);

        // PRESENTATION POSITION

        BaseResponse<List<PresentationPositionVarietyEntity>> GetAllPresentationPositionVariety();
        BaseResponse<List<PresentationPositionVarietyEntity>> GetPresentationPositionVarietyByParthographId(Guid parthographId);
        BaseResponse<PresentationPositionVarietyDto> CreatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto);
        BaseResponse<PresentationPositionVarietyDto> UpdatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto);
        BaseResponse<PresentationPositionVarietyDto> DeletePresentationPositionVariety(PresentationPositionVarietyDto presentationDto);

        // MEDICAL SURVEILLANCE TABLE

        BaseResponse<List<MedicalSurveillanceTableEntity>> GetAllMedicalSurveillanceTable();
        BaseResponse<MedicalSurveillanceTableEntity> GetMedicalSurveillanceTableById(int medicalId);
        BaseResponse<List<MedicalSurveillanceTableEntity>> GetMedicalSurveillanceTableByParthographId(Guid parthographId);
        BaseResponse<MedicalSurveillanceTableDTO> CreateMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto);
        BaseResponse<MedicalSurveillanceTableDTO> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto);
        BaseResponse<MedicalSurveillanceTableDTO> DeleteMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto);
    }
}
