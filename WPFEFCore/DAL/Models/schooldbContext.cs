using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WPFEFCore.DAL.Models
{
    public partial class schooldbContext : DbContext
    {
        public schooldbContext()
        {
        }

        public schooldbContext(DbContextOptions<schooldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Standard> Standard { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studentaddress> Studentaddress { get; set; }
        public virtual DbSet<Studentcourse> Studentcourse { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;user id=testuser;pwd=root;persistsecurityinfo=True;database=schooldb", x => x.ServerVersion("8.0.16-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId).HasColumnType("int(11)");

                entity.Property(e => e.CourseName)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Location)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TeacherId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Standard>(entity =>
            {
                entity.ToTable("standard");

                entity.Property(e => e.StandardId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.StandardName)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RowVersion).HasColumnType("datetime");

                entity.Property(e => e.StandardId)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.StudentName)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Studentaddress>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PRIMARY");

                entity.ToTable("studentaddress");

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Address2)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Studentcourse>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PRIMARY");

                entity.ToTable("studentcourse");

                entity.Property(e => e.StudentId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.Property(e => e.TeacherId).HasColumnType("int(11)");

                entity.Property(e => e.StandardId).HasColumnType("int(11)");

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TeacherType).HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
