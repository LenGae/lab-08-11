using System;
using System.Collections.Generic;

namespace WpfApp8.Entities;

public partial class VwUserPermission
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public string PermissionName { get; set; } = null!;

    public string? PermissionDescription { get; set; }
}
