﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cloud.World.Shared.Database
{
    public partial class DB_CloudWorldContext : DbContext
    {
        public DB_CloudWorldContext()
        {
        }

        public DB_CloudWorldContext(DbContextOptions<DB_CloudWorldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAccount> TbAccount { get; set; }
        public virtual DbSet<TbAnnex> TbAnnex { get; set; }
        public virtual DbSet<TbClass> TbClass { get; set; }
        public virtual DbSet<TbCourseSelection> TbCourseSelection { get; set; }
        public virtual DbSet<TbFile> TbFile { get; set; }
        public virtual DbSet<TbFileType> TbFileType { get; set; }
        public virtual DbSet<TbGlobal> TbGlobal { get; set; }
        public virtual DbSet<TbLog> TbLog { get; set; }
        public virtual DbSet<TbNotice> TbNotice { get; set; }
        public virtual DbSet<TbProject> TbProject { get; set; }
        public virtual DbSet<TbSubject> TbSubject { get; set; }
        public virtual DbSet<TbUser> TbUser { get; set; }
        public virtual DbSet<VAnnex> VAnnex { get; set; }
        public virtual DbSet<VSubmit> VSubmit { get; set; }
        public virtual DbSet<VUser> VUser { get; set; }
        public virtual DbSet<VWork> VWork { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=spaceserver.cloud;Initial Catalog=DB_CloudWorldTest;User ID=ck;Password=pass123!@#");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAccount>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__TB_Accou__C5B69A4A90E15776");

                entity.ToTable("TB_Account");

                entity.Property(e => e.Uid)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbAnnex>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__TB_Annex__C6970A10FF43F559");

                entity.ToTable("TB_Annex");

                entity.Property(e => e.Aid)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Aname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("AName");

                entity.Property(e => e.Apath)
                    .IsRequired()
                    .HasColumnName("APath");

                entity.Property(e => e.Astatus)
                    .HasColumnName("AStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Atime)
                    .HasColumnType("datetime")
                    .HasColumnName("ATime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Atype)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("AType");

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.TbAnnex)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Annex__Pid__29572725");

                entity.HasOne(d => d.PublisherNavigation)
                    .WithMany(p => p.TbAnnex)
                    .HasForeignKey(d => d.Publisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Annex__Publis__2C3393D0");
            });

            modelBuilder.Entity<TbClass>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__TB_Class__C1FFD861B23B7A9F");

                entity.ToTable("TB_Class");

                entity.Property(e => e.Cid)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("CName")
                    .IsFixedLength();

                entity.Property(e => e.Leader)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbCourseSelection>(entity =>
            {
                entity.HasKey(e => e.Index)
                    .HasName("PK__TB_Cours__9A5B6228D3A0721F");

                entity.ToTable("TB_CourseSelection");

                entity.Property(e => e.Cstatus)
                    .HasColumnName("CStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ctime)
                    .HasColumnType("datetime")
                    .HasColumnName("CTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.TbCourseSelection)
                    .HasForeignKey(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_CourseSe__Sid__24927208");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.TbCourseSelection)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_CourseSe__Uid__239E4DCF");
            });

            modelBuilder.Entity<TbFile>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK__TB_File__C1D1314A8F41BC99");

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
                    .HasColumnName("FPath")
                    .HasDefaultValueSql("('Work')");

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
                    .HasConstraintName("FK__TB_File__Pid__300424B4");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.TbFile)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_File__Uid__2F10007B");
            });

            modelBuilder.Entity<TbFileType>(entity =>
            {
                entity.HasKey(e => e.Index)
                    .HasName("PK__TB_FileT__9A5B62282E05F410");

                entity.ToTable("TB_FileType");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<TbGlobal>(entity =>
            {
                entity.HasKey(e => e.Index)
                    .HasName("PK__TB_Globa__9A5B62287B52D318");

                entity.ToTable("TB_Global");

                entity.Property(e => e.Key).IsRequired();
            });

            modelBuilder.Entity<TbLog>(entity =>
            {
                entity.HasKey(e => e.Index)
                    .HasName("PK__TB_Log__9A5B62282F73B89F");

                entity.ToTable("TB_Log");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Batch)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Ip)
                    .HasMaxLength(16)
                    .HasColumnName("IP")
                    .IsFixedLength();

                entity.Property(e => e.Ltime)
                    .HasColumnType("datetime")
                    .HasColumnName("LTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.TbLog)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Log__Uid__3C69FB99");
            });

            modelBuilder.Entity<TbNotice>(entity =>
            {
                entity.HasKey(e => e.Index)
                    .HasName("PK__TB_Notic__9A5B6228DE8367BD");

                entity.ToTable("TB_Notice");

                entity.Property(e => e.Msg).IsRequired();

                entity.Property(e => e.Ntime)
                    .HasColumnType("datetime")
                    .HasColumnName("NTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.HasOne(d => d.PublisherNavigation)
                    .WithMany(p => p.TbNotice)
                    .HasForeignKey(d => d.Publisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Notice__Publi__38996AB5");
            });

            modelBuilder.Entity<TbProject>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__TB_Proje__C57059384E4185F4");

                entity.ToTable("TB_Project");

                entity.Property(e => e.Pid)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PName");

                entity.Property(e => e.Pstatus)
                    .HasColumnName("PStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ptime)
                    .HasColumnType("datetime")
                    .HasColumnName("PTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.PublisherNavigation)
                    .WithMany(p => p.TbProject)
                    .HasForeignKey(d => d.Publisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Projec__Publi__20C1E124");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.TbProject)
                    .HasForeignKey(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Project__Sid__1DE57479");
            });

            modelBuilder.Entity<TbSubject>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__TB_Subje__CA1E5D7847AE1F9D");

                entity.ToTable("TB_Subject");

                entity.Property(e => e.Sid)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SName");

                entity.Property(e => e.Sstatus)
                    .HasColumnName("SStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Stime)
                    .HasColumnType("datetime")
                    .HasColumnName("STime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PublisherNavigation)
                    .WithMany(p => p.TbSubject)
                    .HasForeignKey(d => d.Publisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Subjec__Publi__1B0907CE");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__TB_User__C5B69A4A1F563EA9");

                entity.ToTable("TB_User");

                entity.Property(e => e.Uid)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.Qq)
                    .HasMaxLength(15)
                    .HasColumnName("QQ");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('USER')");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.TbUser)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_User__Cid__15502E78");
            });

            modelBuilder.Entity<VAnnex>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Annex");

                entity.Property(e => e.Aid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Aname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("AName");

                entity.Property(e => e.AnnexPublisher)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Apath)
                    .IsRequired()
                    .HasColumnName("APath");

                entity.Property(e => e.Astatus).HasColumnName("AStatus");

                entity.Property(e => e.Atime)
                    .HasColumnType("datetime")
                    .HasColumnName("ATime");

                entity.Property(e => e.Atype)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("AType");

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PName");

                entity.Property(e => e.ProjectPublisher)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Pstatus).HasColumnName("PStatus");

                entity.Property(e => e.Ptime)
                    .HasColumnType("datetime")
                    .HasColumnName("PTime");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<VSubmit>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Submit");

                entity.Property(e => e.Batch)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.Fid)
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

                entity.Property(e => e.Ftime)
                    .HasColumnType("datetime")
                    .HasColumnName("FTime");

                entity.Property(e => e.Ftype)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("FType");

                entity.Property(e => e.Hash)
                    .HasMaxLength(128)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PName");

                entity.Property(e => e.ProjectPublisher)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Pstatus).HasColumnName("PStatus");

                entity.Property(e => e.Ptime)
                    .HasColumnType("datetime")
                    .HasColumnName("PTime");

                entity.Property(e => e.Qq)
                    .HasMaxLength(15)
                    .HasColumnName("QQ");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<VUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_User");

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("CName")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.Qq)
                    .HasMaxLength(15)
                    .HasColumnName("QQ");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<VWork>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Work");

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PName");

                entity.Property(e => e.ProjectPublisher)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Pstatus).HasColumnName("PStatus");

                entity.Property(e => e.Ptime)
                    .HasColumnType("datetime")
                    .HasColumnName("PTime");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SName");

                entity.Property(e => e.Sstatus).HasColumnName("SStatus");

                entity.Property(e => e.Stime)
                    .HasColumnType("datetime")
                    .HasColumnName("STime");

                entity.Property(e => e.SubjectPublisher)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}