using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestPodologyRepository.Entities;

namespace TestPodologyRepository.Data;

public partial class TestPodologyDBContext : DbContext
{
    public TestPodologyDBContext()
    {
    }

    public TestPodologyDBContext(DbContextOptions<TestPodologyDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consultation> Consultations { get; set; }

    public virtual DbSet<HealthCareProvider> HealthCareProviders { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<RefStatus> RefStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=144.91.109.46;Initial Catalog=TestPodologyDb;User ID=sa;Password=Thom262900.;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.ToTable("Consultation");

            entity.Property(e => e.EndConsultation).HasColumnType("datetime");
            entity.Property(e => e.HealthCareProviderId).HasColumnName("HealthCareProvider_Id");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientInput).HasMaxLength(500);
            entity.Property(e => e.StartConsultation).HasColumnType("datetime");
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");

            entity.HasOne(d => d.HealthCareProvider).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.HealthCareProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consultation_HealthCareProvider");

            entity.HasOne(d => d.Location).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consultation_Location");

            entity.HasOne(d => d.Patient).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consultation_Patient");

            entity.HasOne(d => d.Status).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consultation_Ref_Status");
        });

        modelBuilder.Entity<HealthCareProvider>(entity =>
        {
            entity.ToTable("HealthCareProvider");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.HealthCareProviderId).HasColumnName("HealthCareProvider_Id");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.HealthCareProvider).WithMany(p => p.Locations)
                .HasForeignKey(d => d.HealthCareProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_HealthCareProvider");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.BirthDay).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<RefStatus>(entity =>
        {
            entity.ToTable("Ref_Status");

            entity.Property(e => e.Libelle).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
