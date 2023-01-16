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

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Hour> Hours { get; set; }

    public virtual DbSet<Pointing> Pointings { get; set; }

    public virtual DbSet<PointingStatus> PointingStatuses { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<TypeEmployee> TypeEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=144.91.109.46;User ID=sa;Password=Thom262900.;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.CompanyId).HasMaxLength(250);
            entity.Property(e => e.Deleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Company).WithMany(p => p.AspNetUsers)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_AspNetUsers_Company");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Id).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.ToTable("Device");

            entity.Property(e => e.Id).HasMaxLength(250);
            entity.Property(e => e.CompanyId)
                .HasMaxLength(250)
                .HasColumnName("Company_Id");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.ShopId).HasColumnName("Shop_Id");

            entity.HasOne(d => d.Company).WithMany(p => p.Devices)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Device_Company");

            entity.HasOne(d => d.Shop).WithMany(p => p.Devices)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Device_Shop");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.CompanyId)
                .HasMaxLength(250)
                .HasColumnName("Company_Id");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.NationalNumber).HasMaxLength(50);
            entity.Property(e => e.TypeEmployeeId).HasColumnName("TypeEmployee_Id");

            entity.HasOne(d => d.Company).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Company");

            entity.HasOne(d => d.TypeEmployee).WithMany(p => p.Employees)
                .HasForeignKey(d => d.TypeEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_TypeEmployee");
        });

        modelBuilder.Entity<Hour>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.ShopId, e.Year, e.Week });

            entity.ToTable("Hour");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.ShopId).HasColumnName("Shop_Id");
            entity.Property(e => e.TotalWorkTime).HasMaxLength(10);

            entity.HasOne(d => d.Employee).WithMany(p => p.Hours)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hour_Employee");

            entity.HasOne(d => d.Shop).WithMany(p => p.Hours)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hour_Shop");
        });

        modelBuilder.Entity<Pointing>(entity =>
        {
            entity.ToTable("Pointing");

            entity.HasIndex(e => new { e.ShopId, e.EmployeeId, e.StatusId, e.DatePointing }, "uq_UniqConstaintForPointings").IsUnique();

            entity.Property(e => e.Comment).HasMaxLength(250);
            entity.Property(e => e.CompanyId)
                .HasMaxLength(250)
                .HasColumnName("Company_Id");
            entity.Property(e => e.DatePointing).HasMaxLength(50);
            entity.Property(e => e.DateTimePointing).HasColumnType("datetime");
            entity.Property(e => e.DeviceId)
                .HasMaxLength(250)
                .HasColumnName("Device_Id");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.ShopId).HasColumnName("Shop_Id");
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");

            entity.HasOne(d => d.Company).WithMany(p => p.Pointings)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pointing_Company");

            entity.HasOne(d => d.Device).WithMany(p => p.Pointings)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pointing_Device");

            entity.HasOne(d => d.Employee).WithMany(p => p.Pointings)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pointing_Employee");

            entity.HasOne(d => d.Shop).WithMany(p => p.Pointings)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pointing_Shop");

            entity.HasOne(d => d.Status).WithMany(p => p.Pointings)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pointing_PointingStatus");
        });

        modelBuilder.Entity<PointingStatus>(entity =>
        {
            entity.ToTable("PointingStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DisplayedStatus).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.ToTable("Shop");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Color).HasMaxLength(10);
            entity.Property(e => e.CompanyId)
                .HasMaxLength(250)
                .HasColumnName("Company_Id");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Company).WithMany(p => p.Shops)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shop_Company");

            entity.HasMany(d => d.Employees).WithMany(p => p.Shops)
                .UsingEntity<Dictionary<string, object>>(
                    "ShopEmployee",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Shop_Employee_Employee"),
                    l => l.HasOne<Shop>().WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Shop_Employee_Shop"),
                    j =>
                    {
                        j.HasKey("ShopId", "EmployeeId");
                        j.ToTable("Shop_Employee");
                    });
        });

        modelBuilder.Entity<TypeEmployee>(entity =>
        {
            entity.ToTable("TypeEmployee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
