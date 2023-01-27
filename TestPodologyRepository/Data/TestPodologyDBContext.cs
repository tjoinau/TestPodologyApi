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

    public virtual DbSet<LocationHealthCareProvider> LocationHealthCareProviders { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<RefStatus> RefStatuses { get; set; }

    public virtual DbSet<RefUserType> RefUserTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=144.91.109.46;Initial Catalog=TestPodologyDb;User ID=sa;Password=Thom262900.;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.ToTable("Consultation");

            entity.Property(e => e.EndConsultation).HasColumnType("datetime");
            entity.Property(e => e.HealthCareProviderId)
                .HasMaxLength(150)
                .HasColumnName("HealthCareProvider_Id");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.PatientId)
                .HasMaxLength(150)
                .HasColumnName("Patient_Id");
            entity.Property(e => e.PatientInput).HasMaxLength(500);
            entity.Property(e => e.StartConsultation).HasColumnType("datetime");
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");

            entity.HasOne(d => d.HealthCareProvider).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.HealthCareProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consultation_HealthCareProvider1");

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

            entity.Property(e => e.Id)
                .HasMaxLength(150)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .HasDefaultValueSql("(N'#65aee7')");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<LocationHealthCareProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Table_1");

            entity.ToTable("Location_HealthCareProvider");

            entity.Property(e => e.HealthCareProviderId).HasMaxLength(150);

            entity.HasOne(d => d.HealthCareProvider).WithMany(p => p.LocationHealthCareProviders)
                .HasForeignKey(d => d.HealthCareProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_HealthCareProvider_HealthCareProvider");

            entity.HasOne(d => d.Location).WithMany(p => p.LocationHealthCareProviders)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_HealthCareProvider_Location");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.Id)
                .HasMaxLength(150)
                .HasDefaultValueSql("(newid())");
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

        modelBuilder.Entity<RefUserType>(entity =>
        {
            entity.ToTable("RefUserType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Libelle).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.RefUserTypeId).HasColumnName("RefUserType_Id");
            entity.Property(e => e.RegisterNumber).HasMaxLength(50);

            entity.HasOne(d => d.RefUserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.RefUserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_RefUserType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
