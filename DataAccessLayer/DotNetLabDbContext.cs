using System;
using System.Collections.Generic;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public partial class DotNetLabDbContext : DbContext
{
    public DotNetLabDbContext()
    {
    }

    public DotNetLabDbContext(DbContextOptions<DotNetLabDbContext> options)
        : base(options)
    {
        Database.EnsureCreated(); //creating new DB if current does not exists
    }

    public virtual DbSet<AudioMedia> AudioMedia { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=E:\\projects\\c#_projects\\DotNetLab\\DotNetLabTemplate\\DotNetLabTemplate\\DotNetLabDB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AudioMedia>(entity =>
        {
            entity.HasIndex(e => new { e.AlbumName, e.Artist }, "IX_AudioMedia_AlbumName_Artist").IsUnique();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.Store).WithMany(p => p.Employees)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.Sales)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Store).WithMany(p => p.Sales)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
