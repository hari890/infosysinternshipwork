using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infosys.DBFirstCore.DataAccessLayer.Models;

public partial class QuestBankDbContext : DbContext
{
    public QuestBankDbContext()
    {
    }

    public QuestBankDbContext(DbContextOptions<QuestBankDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<AudioQuestion> AudioQuestions { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<McqQuestion> McqQuestions { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionType> QuestionTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog=QuestBankDB;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AudioQuestion>(entity =>
        {
            entity.HasKey(e => e.AudioQuestionId).HasName("pk_AudioQuestionid");

            entity.ToTable("Audio_Questions");

            entity.HasIndex(e => e.QuestionId, "UQ__Audio_Qu__0DC06FAD8286F8E3").IsUnique();

            entity.Property(e => e.AudioFilePath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Audio_file_path");
            entity.Property(e => e.QustionDesc)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Question).WithOne(p => p.AudioQuestion)
                .HasForeignKey<AudioQuestion>(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_questionid2");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("pk_Categoryid");

            entity.HasIndex(e => e.CategoryName, "uq_CategoryName").IsUnique();

            entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<McqQuestion>(entity =>
        {
            entity.HasKey(e => e.McqquestionId).HasName("pk_MCQQuestionid");

            entity.ToTable("MCQ_Questions");

            entity.Property(e => e.McqquestionId).HasColumnName("MCQQuestionId");
            entity.Property(e => e.QustionDesc)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Question).WithMany(p => p.McqQuestions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_questionid1");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("pk_Questionid");

            entity.Property(e => e.IsAccepted)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PostDate).HasColumnType("date");
            entity.Property(e => e.PostedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReviewDate).HasColumnType("date");
            entity.Property(e => e.ReviewedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Questions)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_categoryid");

            entity.HasOne(d => d.PostedByNavigation).WithMany(p => p.QuestionPostedByNavigations)
                .HasForeignKey(d => d.PostedBy)
                .HasConstraintName("fk_userid1");

            entity.HasOne(d => d.QuestionType).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuestionTypeId)
                .HasConstraintName("fk_questiontypeid");

            entity.HasOne(d => d.ReviewedByNavigation).WithMany(p => p.QuestionReviewedByNavigations)
                .HasForeignKey(d => d.ReviewedBy)
                .HasConstraintName("fk_userid2");
        });

        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.HasKey(e => e.QuestionTypeId).HasName("pk_QuestionTypeId");

            entity.ToTable("QuestionType");

            entity.HasIndex(e => e.QuestionType1, "uq_QuestionType").IsUnique();

            entity.Property(e => e.QuestionTypeId).ValueGeneratedOnAdd();
            entity.Property(e => e.QuestionType1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("QuestionType");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("pk_RoleId");

            entity.HasIndex(e => e.RoleName, "uq_RoleName").IsUnique();

            entity.Property(e => e.RoleId).ValueGeneratedOnAdd();
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("pk_userid");

            entity.ToTable("users");

            entity.Property(e => e.Userid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_Roleid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
