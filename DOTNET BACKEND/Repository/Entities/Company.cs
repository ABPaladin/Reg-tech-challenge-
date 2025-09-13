using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Address { get; set; }

    public string? ResponsibleName { get; set; }

    public string? ResponsiblePhone { get; set; }

    public string? ResponsibleEmail { get; set; }

    public string? Size { get; set; }

    public string? SectorType { get; set; }

    public string? IsoCertified { get; set; }

    public string? RiskAssesment { get; set; }

    public string? RiskSolution { get; set; }

    public string? OpsecTools { get; set; }

    public virtual ICollection<CompanyIp> CompanyIps { get; set; } = new List<CompanyIp>();

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();
}
