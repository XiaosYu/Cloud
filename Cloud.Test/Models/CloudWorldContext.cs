﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cloud.Test.Models
{
    public partial class CloudWorldContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public CloudWorldContext()
        {
        }

        public CloudWorldContext(DbContextOptions<CloudWorldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAccount> TbAccount { get; set; }
        public virtual DbSet<TbFile> TbFile { get; set; }
        public virtual DbSet<TbLog> TbLog { get; set; }
        public virtual DbSet<TbProject> TbProject { get; set; }
        public virtual DbSet<TbSubject> TbSubject { get; set; }
        public virtual DbSet<TbUser> TbUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=spaceserver.cloud,1433;Initial Catalog=CloudWorld;User ID=ck;Password=pass123!@#;Trust Server Certificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAccount>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__TB_Accou__C5B69A4A28AD1845");

                entity.ToTable("TB_Account");

                entity.Property(e => e.Uid)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasDefaultValueSql("('123456')");
            });

            modelBuilder.Entity<TbFile>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK__TB_File__C1D1314A06B18F7C");

                entity.ToTable("TB_File");

                entity.Property(e => e.Fid)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Batch)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName");

                entity.Property(e => e.Fpath)
                    .IsRequired()
                    .HasColumnName("FPath");

                entity.Property(e => e.Fstatus)
                    .HasColumnName("FStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ftime)
                    .HasColumnType("datetime")
                    .HasColumnName("FTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ftype)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("FType")
                    .HasDefaultValueSql("('*')");

                entity.Property(e => e.Hash)
                    .HasMaxLength(128)
                    .IsFixedLength();

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.TbFile)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_File__Pid__75A278F5");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.TbFile)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_File__Uid__74AE54BC");
            });

            modelBuilder.Entity<TbLog>(entity =>
            {
                entity.HasKey(e => e.Index)
                    .HasName("PK__TB_Log__9A5B6228CF82CF8A");

                entity.ToTable("TB_Log");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.LogTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.TbLog)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Log__Uid__6754599E");
            });

            modelBuilder.Entity<TbProject>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__TB_Proje__C57059383A13BD53");

                entity.ToTable("TB_Project");

                entity.Property(e => e.Pid)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("PName");

                entity.Property(e => e.Pstatus)
                    .HasColumnName("PStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ptime)
                    .HasColumnType("datetime")
                    .HasColumnName("PTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RequiredType).HasDefaultValueSql("('*')");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.TbProject)
                    .HasForeignKey(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Project__Sid__6EF57B66");
            });

            modelBuilder.Entity<TbSubject>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__TB_Subje__CA1E5D780BD1932E");

                entity.ToTable("TB_Subject");

                entity.Property(e => e.Sid)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("SName");

                entity.Property(e => e.Sstatus)
                    .HasColumnName("SStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Stime)
                    .HasColumnType("datetime")
                    .HasColumnName("STime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__TB_User__C5B69A4A609BC596");

                entity.ToTable("TB_User");

                entity.Property(e => e.Uid)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.Qq)
                    .HasMaxLength(15)
                    .HasColumnName("QQ");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}