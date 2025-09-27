using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF1.Models;

public partial class UniversityContext : DbContext
{
    public UniversityContext()
    {
    }

    public UniversityContext(DbContextOptions<UniversityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=University;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__2AA84FD13DF3FB2C");

            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CName)
                .HasMaxLength(50)
                .HasColumnName("cName");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.ProfessorId).HasColumnName("professorId");

            entity.HasOne(d => d.Professor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("FK__Courses__profess__3B75D760");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Enrollment1).HasName("PK__Enrollme__F812BC226F67BFEF");

            entity.Property(e => e.Enrollment1).HasColumnName("Enrollment");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Grade)
                .HasMaxLength(10)
                .HasColumnName("grade");
            entity.Property(e => e.StudentId).HasColumnName("studentId");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Enrollmen__cours__3F466844");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Enrollmen__stude__3E52440B");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.ProfessorId).HasName("PK__Professo__9601F5DB5A182F1C");

            entity.Property(e => e.ProfessorId).HasColumnName("professorId");
            entity.Property(e => e.PfirstName)
                .HasMaxLength(20)
                .HasColumnName("pfirstName");
            entity.Property(e => e.PlastName)
                .HasMaxLength(20)
                .HasColumnName("plastName");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__4D11D63C8C1AE970");

            entity.Property(e => e.StudentId).HasColumnName("studentId");
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .HasColumnName("adress");
            entity.Property(e => e.BirthDate).HasColumnName("birthDate");
            entity.Property(e => e.SfirstName)
                .HasMaxLength(20)
                .HasColumnName("sfirstName");
            entity.Property(e => e.SlastName)
                .HasMaxLength(20)
                .HasColumnName("slastName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
