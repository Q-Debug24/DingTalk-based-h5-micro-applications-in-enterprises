using DingDingPuls.Models;
using Microsoft.EntityFrameworkCore;

namespace DingDingPuls.Datas
{
    public partial class DingDingDBContext : DbContext
    {
        public DingDingDBContext()
        {
        }

        public DingDingDBContext(DbContextOptions<DingDingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DepartmentTable> DepartmentTable { get; set; }
        public virtual DbSet<LegerTable> LegerTable { get; set; }
        public virtual DbSet<RepairTable> RepairTable { get; set; }
        public virtual DbSet<CheckTable> CheckTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KOBE;Database=DingDingDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentTable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LegerTable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AssetsClass)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AssetsName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndTime).HasColumnType("date");

                entity.Property(e => e.EquipmentType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImgUrl).HasMaxLength(50);

                entity.Property(e => e.StartTime).HasColumnType("date");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.LegerTable)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LegerTable_DepartmentTable");
            });

            modelBuilder.Entity<RepairTable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Applicant).HasMaxLength(50);

                entity.Property(e => e.BrokenTime).HasColumnType("date");

                entity.Property(e => e.CheckStatus).HasMaxLength(50);

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.EndTime).HasColumnType("date");

                entity.Property(e => e.Leader).HasMaxLength(50);

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.PlanTime).HasColumnType("date");

                entity.Property(e => e.Reason).HasMaxLength(50);

                entity.Property(e => e.StartTime).HasColumnType("date");

                entity.Property(e => e.WorkerName).HasMaxLength(50);

                entity.Property(e => e.Workers).HasMaxLength(50);

                entity.HasOne(d => d.Assets)
                    .WithMany(p => p.RepairTable)
                    .HasForeignKey(d => d.AssetsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepairTable_LegerTable");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.RepairTable)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepairTable_DepartmentTable");
            });

            modelBuilder.Entity<CheckTable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Applicant).HasMaxLength(50);

                entity.Property(e => e.CheckAreas).HasMaxLength(50);

                entity.Property(e => e.CheckCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CheckCyc).HasMaxLength(50);

                entity.Property(e => e.CheckEndTime).HasColumnType("date");

                entity.Property(e => e.CheckPlanTime).HasColumnType("date");

                entity.Property(e => e.CheckResult).HasMaxLength(50);

                entity.Property(e => e.CheckStartTime).HasColumnType("date");

                entity.Property(e => e.CheckStatus).HasMaxLength(50);

                entity.Property(e => e.Leader).HasMaxLength(50);

                entity.Property(e => e.EquName).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(50);

                entity.Property(e => e.WorkerName).HasMaxLength(50);

                entity.HasOne(d => d.Assets)
                    .WithMany(p => p.CheckTable)
                    .HasForeignKey(d => d.AssetsId)
                    .OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false)
                    .HasConstraintName("FK_CheckTable_LegerTable");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.CheckTable)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false)
                    .HasConstraintName("FK_CheckTable_DepartmentTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}