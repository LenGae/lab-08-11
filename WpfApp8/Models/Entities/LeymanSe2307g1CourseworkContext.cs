using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp8.Entities;

public partial class LeymanSe2307g1CourseworkContext : DbContext
{
    public LeymanSe2307g1CourseworkContext()
    {
    }

    public LeymanSe2307g1CourseworkContext(DbContextOptions<LeymanSe2307g1CourseworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aircraft> Aircraft { get; set; }

    public virtual DbSet<AircraftStatusHistory> AircraftStatusHistories { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VwAircraftAvailability> VwAircraftAvailabilities { get; set; }

    public virtual DbSet<VwBookingDetail> VwBookingDetails { get; set; }

    public virtual DbSet<VwRolePermissionsSummary> VwRolePermissionsSummaries { get; set; }

    public virtual DbSet<VwUserPermission> VwUserPermissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DBSRV\\ag2025;Initial Catalog='LeymanSE2307g1 Coursework';Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aircraft>(entity =>
        {
            entity.HasKey(e => e.AircraftId).HasName("PK__Aircraft__F75CBC0B7BB41FE8");

            entity.ToTable(tb => tb.HasTrigger("tr_Aircraft_StatusChange"));

            entity.HasIndex(e => e.IsAvailable, "IX_Aircraft_IsAvailable");

            entity.HasIndex(e => e.Status, "IX_Aircraft_Status");

            entity.HasIndex(e => e.Type, "IX_Aircraft_Type");

            entity.HasIndex(e => e.RegistrationNumber, "UQ__Aircraft__E88646028DEFDA66").IsUnique();

            entity.Property(e => e.AircraftId).HasColumnName("AircraftID");
            entity.Property(e => e.BasePricePerHour).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ImageUrl).HasMaxLength(1000);
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.RegistrationNumber).HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Available");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<AircraftStatusHistory>(entity =>
        {
            entity.HasKey(e => e.StatusHistoryId).HasName("PK__Aircraft__DB9734B1FE13D14D");

            entity.ToTable("AircraftStatusHistory");

            entity.HasIndex(e => e.AircraftId, "IX_AircraftStatusHistory_AircraftID");

            entity.HasIndex(e => e.ChangeDate, "IX_AircraftStatusHistory_ChangeDate");

            entity.Property(e => e.StatusHistoryId).HasColumnName("StatusHistoryID");
            entity.Property(e => e.AircraftId).HasColumnName("AircraftID");
            entity.Property(e => e.ChangeDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ChangedByUserId).HasColumnName("ChangedByUserID");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Aircraft).WithMany(p => p.AircraftStatusHistories)
                .HasForeignKey(d => d.AircraftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AircraftS__Aircr__2E70E1FD");

            entity.HasOne(d => d.ChangedByUser).WithMany(p => p.AircraftStatusHistories)
                .HasForeignKey(d => d.ChangedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AircraftS__Chang__2F650636");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACDFEA8CA86");

            entity.ToTable("Booking", tb => tb.HasTrigger("tr_Booking_UpdateTimestamp"));

            entity.HasIndex(e => e.AircraftId, "IX_Booking_AircraftID");

            entity.HasIndex(e => new { e.StartDateTime, e.EndDateTime }, "IX_Booking_Dates");

            entity.HasIndex(e => e.Status, "IX_Booking_Status");

            entity.HasIndex(e => e.UserId, "IX_Booking_UserID");

            entity.HasIndex(e => new { e.UserId, e.Status }, "IX_Booking_User_Status");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.AircraftId).HasColumnName("AircraftID");
            entity.Property(e => e.CancellationReason).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Aircraft).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.AircraftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Aircraf__23F3538A");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__UserID__22FF2F51");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB0F68368F63");

            entity.HasIndex(e => e.PermissionName, "UQ__Permissi__0FFDA35751442EAB").IsUnique();

            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.PermissionName).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Role1).HasName("PK__Roles__DA15413F6A848002");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B61608CCD89F7").IsUnique();

            entity.Property(e => e.Role1).HasColumnName("Role");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RoleName).HasMaxLength(20);
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => new { e.Role, e.PermissionId }).HasName("PK__RolePerm__34EF2E8FBFF4CC31");

            entity.HasIndex(e => e.PermissionId, "IX_RolePermissions_PermissionID");

            entity.HasIndex(e => e.Role, "IX_RolePermissions_Role");

            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.GrantedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RolePermi__Permi__0D0FEE32");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RolePermis__Role__0C1BC9F9");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACBE6EB8C2");

            entity.HasIndex(e => e.Email, "IX_Users_Email");

            entity.HasIndex(e => e.IsActive, "IX_Users_IsActive");

            entity.HasIndex(e => e.Role, "IX_Users_Role");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105342E7F5D97").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__Role__11D4A34F");
        });

        modelBuilder.Entity<VwAircraftAvailability>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AircraftAvailability");

            entity.Property(e => e.AircraftId).HasColumnName("AircraftID");
            entity.Property(e => e.AvailabilityStatus)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.BasePricePerHour).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.RegistrationNumber).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<VwBookingDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_BookingDetails");

            entity.Property(e => e.AircraftModel).HasMaxLength(100);
            entity.Property(e => e.AircraftType).HasMaxLength(50);
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookingStatus).HasMaxLength(20);
            entity.Property(e => e.ClientEmail).HasMaxLength(255);
            entity.Property(e => e.ClientName).HasMaxLength(100);
            entity.Property(e => e.RegistrationNumber).HasMaxLength(20);
            entity.Property(e => e.TotalCost).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VwRolePermissionsSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RolePermissionsSummary");

            entity.Property(e => e.PermissionsList).HasMaxLength(4000);
            entity.Property(e => e.RoleName).HasMaxLength(20);
        });

        modelBuilder.Entity<VwUserPermission>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UserPermissions");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PermissionDescription).HasMaxLength(255);
            entity.Property(e => e.PermissionName).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(20);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
