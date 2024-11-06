using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp3.Models;

public partial class QlsvContext : DbContext
{
    public QlsvContext()
    {
    }

    public QlsvContext(DbContextOptions<QlsvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TsinhVien> TsinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-QCE8DGMH\\MSSQLSERVER01;Initial Catalog=QLSV;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TsinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSo).HasName("PK_MaSo");

            entity.ToTable("TSinhVien");

            entity.Property(e => e.MaSo).ValueGeneratedNever();
            entity.Property(e => e.DiaChi)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.HoTen)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
