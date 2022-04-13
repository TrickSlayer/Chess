using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Chess.Models
{
    public partial class ChessContext : DbContext
    {
        public ChessContext()
        {
        }

        public ChessContext(DbContextOptions<ChessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HOANGDAT; database=Chess; user=sa; password=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.ToTable("Achievement");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Player1Id).HasColumnName("player1Id");

                entity.Property(e => e.Player2Id).HasColumnName("player2Id");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");

                entity.HasOne(d => d.Player1)
                    .WithMany(p => p.AchievementPlayer1s)
                    .HasForeignKey(d => d.Player1Id)
                    .HasConstraintName("FK__Achieveme__playe__267ABA7A");

                entity.HasOne(d => d.Player2)
                    .WithMany(p => p.AchievementPlayer2s)
                    .HasForeignKey(d => d.Player2Id)
                    .HasConstraintName("FK__Achieveme__playe__276EDEB3");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
