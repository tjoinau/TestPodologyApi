﻿namespace TestPodologyModel.DTOs
{
    public class NewConsultationDto
    {
        public int PatientId { get; set; }

        public int HealthCareProviderId { get; set; }

        public int LocationId { get; set; }

        public DateTime StartConsultation { get; set; }

        public string? PatientInput { get; set; }

    }
}