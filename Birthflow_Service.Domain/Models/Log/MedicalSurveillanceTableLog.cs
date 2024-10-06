﻿
namespace BirthflowService.Domain.Models.Log
{
    public class MedicalSurveillanceTableLog
    {
        public string MaternalPosition { get; set; } = null!;
        public string ArterialPressure { get; set; } = null!;
        public string MaternalPulse { get; set; } = null!;
        public string FetalHeartRate { get; set; } = null!;
        public string ContractionsDuration { get; set; } = null!;
        public string FrequencyContractions { get; set; } = null!;
        public string Pain { get; set; } = null!;
        public char Letter { get; set; }
        public DateTime Time { get; set; }
    }
}
