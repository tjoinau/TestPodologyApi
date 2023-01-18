using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class Consultation
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    public int PatientId { get; set; }

    public int HealthCareProviderId { get; set; }

    public int LocationId { get; set; }

    public DateTime StartConsultation { get; set; }

    public DateTime EndConsultation { get; set; }

    public string? PatientInput { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual HealthCareProvider HealthCareProvider { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual RefStatus Status { get; set; } = null!;
}
