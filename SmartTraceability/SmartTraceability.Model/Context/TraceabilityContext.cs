using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartTraceability.Model.Models;

#nullable disable

namespace SmartTraceability.Model.Context
{
    public partial class TraceabilityContext : DbContext
    {
        public TraceabilityContext()
        {
        }

        public TraceabilityContext(DbContextOptions<TraceabilityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Incubator> Incubators { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename= D:\\vs2019\\SmartTraceability\\SmartTraceability\\SmartTraceability.Model\\Data\\Entities\\Traceability.mdf;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.Property(e => e.DataReaded).HasMaxLength(300);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Incubator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SerialCode)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeBegin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeEnd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IncubatorNavigation)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.IncubatorId)
                    .HasConstraintName("FK_Entries_Incubators");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Entries_Users");
            });

            modelBuilder.Entity<Incubator>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KeyActivation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SerialCode)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Updated).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
