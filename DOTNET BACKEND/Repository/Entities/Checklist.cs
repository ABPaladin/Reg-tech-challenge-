using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Checklist
{
    public int Id { get; set; }

    public int CompanyIpId { get; set; }

    public DateTime Datetime { get; set; }

    public virtual CompanyIp CompanyIp { get; set; } = null!;
}
