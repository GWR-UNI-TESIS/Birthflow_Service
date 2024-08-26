using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Infraestructure.Utils
{
    public static class DtoMapper
    {
        public static PresentationPositionVarietyEntity ConvertPresentationPositionVarietyDto_Entity(this PresentationPositionVarietyDto data)
        {
            var result = new PresentationPositionVarietyEntity()
            {
                Id = data.Id,
                PartographId = data.PartographId,
                HodgePlane = data.HodgePlane,
                Position = data.Position,
                Time = data.Time,
            };

            return result;
        }

        public static MedicalSurveillanceTableEntity ConvertMedicalSurveillanceTableDto_Entity(this MedicalSurveillanceTableDTO data)
        {
            var result = new MedicalSurveillanceTableEntity()
            {
                Id = data.Id,
                PartographId = data.PartographId,
                MaternalPosition = data.MaternalPosition,
                Letter = data.Letter,
                ArterialPressure = data.ArterialPressure,
                MaternalPulse = data.MaternalPulse,
                FetalHeartRate = data.FetalHeartRate,
                ContractionsDuration = data.ContractionsDuration,
                FrequencyContractions = data.FrequencyContractions,
                Pain = data.Pain
            };

            return result;
        }
    }
}
