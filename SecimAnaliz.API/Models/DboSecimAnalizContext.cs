using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SecimAnaliz.API.Models
{
    public partial class DboSecimAnalizContext : DbContext
    {
        public DboSecimAnalizContext()
        {
        }

        public DboSecimAnalizContext(DbContextOptions<DboSecimAnalizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblOy> TblOys { get; set; }
        public virtual DbSet<TblParti> TblPartis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SL1S3RQ\\SQLEXPRESS;Database=DboSecimAnaliz;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<TblOy>(entity =>
            {
                entity.ToTable("Tbl_Oy");

                entity.Property(e => e.SistemGirisTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Parti)
                    .WithMany(p => p.TblOys)
                    .HasForeignKey(d => d.PartiId)
                    .HasConstraintName("FK__Tbl_Oy__PartiId__4BAC3F29");
            });

            modelBuilder.Entity<TblParti>(entity =>
            {
                entity.ToTable("Tbl_Parti");

                entity.Property(e => e.PartiAdi)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
