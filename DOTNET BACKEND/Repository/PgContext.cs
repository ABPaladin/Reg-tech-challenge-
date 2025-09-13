using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository;

public partial class PgContext : DbContext
{
    public PgContext(DbContextOptions<PgContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AutomaticCheck> AutomaticChecks { get; set; }

    public virtual DbSet<AutomaticCheckAuditHeader> AutomaticCheckAuditHeaders { get; set; }

    public virtual DbSet<AutomaticCheckAuditRow> AutomaticCheckAuditRows { get; set; }

    public virtual DbSet<Checklist> Checklists { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyIp> CompanyIps { get; set; }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<IncidentStatus> IncidentStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AutomaticCheck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("automatic_checks_pkey");

            entity.ToTable("automatic_checks");

            entity.HasIndex(e => e.Name, "automatic_checks_name_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<AutomaticCheckAuditHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("automatic_check_audit_headers_pkey");

            entity.ToTable("automatic_check_audit_headers");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CompanyIpId).HasColumnName("company_ip_id");
            entity.Property(e => e.Datetime)
                .HasDefaultValueSql("now()")
                .HasColumnName("datetime");

            entity.HasOne(d => d.CompanyIp).WithMany(p => p.AutomaticCheckAuditHeaders)
                .HasForeignKey(d => d.CompanyIpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("automatic_check_audit_headers_company_ip_id_fkey");
        });

        modelBuilder.Entity<AutomaticCheckAuditRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("automatic_check_audit_rows_pkey");

            entity.ToTable("automatic_check_audit_rows");

            entity.HasIndex(e => new { e.AutomaticCheckAuditHeaderId, e.AutomaticCheckId }, "automatic_check_audit_rows_automatic_check_audit_header_id__key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AutomaticCheckAuditHeaderId).HasColumnName("automatic_check_audit_header_id");
            entity.Property(e => e.AutomaticCheckId).HasColumnName("automatic_check_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Passed).HasColumnName("passed");

            entity.HasOne(d => d.AutomaticCheckAuditHeader).WithMany(p => p.AutomaticCheckAuditRows)
                .HasForeignKey(d => d.AutomaticCheckAuditHeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("automatic_check_audit_rows_automatic_check_audit_header_id_fkey");

            entity.HasOne(d => d.AutomaticCheck).WithMany(p => p.AutomaticCheckAuditRows)
                .HasForeignKey(d => d.AutomaticCheckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("automatic_check_audit_rows_automatic_check_id_fkey");
        });

        modelBuilder.Entity<Checklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("checklists_pkey");

            entity.ToTable("checklists");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CompanyIpId).HasColumnName("company_ip_id");
            entity.Property(e => e.Datetime)
                .HasDefaultValueSql("now()")
                .HasColumnName("datetime");

            entity.HasOne(d => d.CompanyIp).WithMany(p => p.Checklists)
                .HasForeignKey(d => d.CompanyIpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("checklists_company_ip_id_fkey");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("companies_pkey");

            entity.ToTable("companies");

            entity.HasIndex(e => e.Password, "companies_password_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
        });

        modelBuilder.Entity<CompanyIp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("company_ips_pkey");

            entity.ToTable("company_ips");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Url).HasColumnName("url");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyIps)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("company_ips_company_id_fkey");
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("incidents_pkey");

            entity.ToTable("incidents");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.FirstResponse).HasColumnName("first_response");
            entity.Property(e => e.FirstResponseTimestamp)
                .HasDefaultValueSql("now()")
                .HasColumnName("first_response_timestamp");
            entity.Property(e => e.IsCritical).HasColumnName("is_critical");
            entity.Property(e => e.IsInitiallyAverted).HasColumnName("is_initially_averted");
            entity.Property(e => e.RepeatIncidentId).HasColumnName("repeat_incident_id");
            entity.Property(e => e.SecondResponse).HasColumnName("second_response");
            entity.Property(e => e.SecondResponseTimestamp).HasColumnName("second_response_timestamp");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.ThirdResponse).HasColumnName("third_response");
            entity.Property(e => e.ThirdResponseTimestamp).HasColumnName("third_response_timestamp");

            entity.HasOne(d => d.Company).WithMany(p => p.Incidents)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("incidents_company_id_fkey");

            entity.HasOne(d => d.RepeatIncident).WithMany(p => p.InverseRepeatIncident)
                .HasForeignKey(d => d.RepeatIncidentId)
                .HasConstraintName("incidents_repeat_incident_id_fkey");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Incidents)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("incidents_status_fkey");
        });

        modelBuilder.Entity<IncidentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("incident_statuses_pkey");

            entity.ToTable("incident_statuses");

            entity.HasIndex(e => e.Name, "incident_statuses_name_key").IsUnique();

            entity.HasIndex(e => e.StatusOrder, "incident_statuses_status_order_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.StatusOrder).HasColumnName("status_order");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
