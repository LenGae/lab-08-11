using System;
using System.Collections.Generic;

namespace WpfApp8.Entities;

public partial class VwRolePermissionsSummary
{
    public string RoleName { get; set; } = null!;

    public int? PermissionCount { get; set; }

    public string? PermissionsList { get; set; }
}
