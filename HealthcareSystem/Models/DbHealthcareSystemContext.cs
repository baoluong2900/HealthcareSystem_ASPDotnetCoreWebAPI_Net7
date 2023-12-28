using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Models;

public partial class DbHealthcareSystemContext : DbContext
{
    public DbHealthcareSystemContext()
    {
    }

    public DbHealthcareSystemContext(DbContextOptions<DbHealthcareSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<HealthComment> HealthComments { get; set; }

    public virtual DbSet<HealthRecord> HealthRecords { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UsersHealthRecordId> UsersHealthRecordIds { get; set; }

    public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseSqlServer("Server=sql-server-285.database.windows.net;Database=dw;Trusted_Connection=False;Encrypt=True;User Id=dw-user;Password=Baodandy3@;");
    //  => optionsBuilder.UseSqlServer("Server=BAOLUONG;Database=dbHealthcareSystem;Trusted_Connection=False;Encrypt=False;User Id=sa;Password=123456;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AcoountId);

            entity.ToTable("Account");

            entity.Property(e => e.AcoountId).HasColumnName("AcoountID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);
            entity.Property(e => e.UserNo)
                .HasMaxLength(255)
                .IsFixedLength();
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.AppointmentTime).HasColumnType("datetime");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Payment).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Appointments_Users");
        });

        modelBuilder.Entity<HealthComment>(entity =>
        {
            entity.HasKey(e => e.HealthCommentId).HasName("PK__HealthCo__F7B647E06FC50FDB");

            entity.Property(e => e.HealthCommentId).HasColumnName("HealthCommentID");
            entity.Property(e => e.CommentedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HealthRecordId).HasColumnName("HealthRecordID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
        });

        modelBuilder.Entity<HealthRecord>(entity =>
        {
            entity.HasKey(e => e.HealthRecordId).HasName("PK__HealthRe__3BE0B89D2E8E6AF4");

            entity.Property(e => e.HealthRecordId).HasColumnName("HealthRecordID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.UrineColor).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WaistCircumference).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.HealthRecords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_HealthRecords_Users1");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA4772EB0D5AF");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameWithType).HasMaxLength(100);
            entity.Property(e => e.Slug).HasMaxLength(100);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AEC2B7F3D5");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Service).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Reviews_Services1");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__C51BB0EAC2E33B8E");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceName).HasMaxLength(255);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.Staff).WithMany(p => p.Services)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_Services_Staffs1");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staffs__C33E2C4F4EB708A8");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.JoinDate).HasColumnType("date");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NationalId)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("NationalID");
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.Qualifications).HasMaxLength(255);
            entity.Property(e => e.SaltPassword)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Sex).HasMaxLength(10);
            entity.Property(e => e.Specialization).HasMaxLength(100);
            entity.Property(e => e.StaffNo)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.TerminationDate).HasColumnType("date");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE66694233456ED");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Fax).HasMaxLength(15);
            entity.Property(e => e.LicenseNumber).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.RegistrationDate).HasColumnType("date");
            entity.Property(e => e.SupplierName).HasMaxLength(255);
            entity.Property(e => e.SupplierType).HasMaxLength(255);
            entity.Property(e => e.TaxId)
                .HasMaxLength(20)
                .HasColumnName("TaxID");
            entity.Property(e => e.Tin)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("TIN");
            entity.Property(e => e.Website).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC3E8D8CFC");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NationalId)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("NationalID");
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.SaltPassword)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Sex).HasMaxLength(10);
            entity.Property(e => e.UserNo)
                .HasMaxLength(255)
                .IsFixedLength();
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A55AFDE2EE1");

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.RoleName).HasMaxLength(50);
            entity.Property(e => e.UserRoleNo)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<UsersHealthRecordId>(entity =>
        {
            entity.HasKey(e => e.UsersHealthRecordId1).HasName("PK__Users_He__A92E0F20B2F9F50E");

            entity.ToTable("Users_HealthRecordID");

            entity.Property(e => e.UsersHealthRecordId1).HasColumnName("Users_HealthRecordID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HealthRecordId).HasColumnName("HealthRecordID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<WorkSchedule>(entity =>
        {
            entity.HasKey(e => e.WorkScheduleId).HasName("PK__WorkSche__C6AC635E7CAFC7B3");

            entity.Property(e => e.WorkScheduleId).HasColumnName("WorkScheduleID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.WorkDate).HasColumnType("date");

            entity.HasOne(d => d.Staff).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_WorkSchedules_Staffs");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
