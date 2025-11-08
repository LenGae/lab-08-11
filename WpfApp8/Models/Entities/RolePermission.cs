using System;
using System.Collections.Generic;

namespace WpfApp8.Entities;

public partial class RolePermission
{
    public int Role { get; set; }

    public int PermissionId { get; set; }

    public DateTime GrantedAt { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role RoleNavigation { get; set; } = null!;
}
