using System;
using System.Collections.Generic;
using HRDesk.DL.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace HRDesk.DL.Context;

public partial class DbfirstApproachContext : DbContext
{
    public DbfirstApproachContext()
    {
    }

    public DbfirstApproachContext(DbContextOptions<DbfirstApproachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-JFDKH3EF\\MSSQLSERVER22;Database=HRDesk;Trusted_Connection=false;Encrypt=False;TrustServerCertificate=False;Connect Timeout=30;user id=sa;password=test;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3214EC0796B7D243");

            entity.ToTable("employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dob).HasColumnType("datetime");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_UserID");

            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK_UserType");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("PK__UserType__40D2D8F63DE97020");

            entity.ToTable("UserType");

            entity.Property(e => e.UserTypeId)
                .ValueGeneratedNever()
                .HasColumnName("UserTypeID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.TypeName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
