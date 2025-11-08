using System;
using System.Collections.Generic;

namespace WpfApp8.Entities;

public partial class Role
{
    public int Role1 { get; set; }

    public string RoleName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
