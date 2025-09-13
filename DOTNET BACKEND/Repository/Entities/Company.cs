using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<CompanyIp> CompanyIps { get; set; } = new List<CompanyIp>();

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();
}
