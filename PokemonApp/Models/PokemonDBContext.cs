using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PokemonApp.Models
{
    public partial class PokemonDBContext : DbContext
    {
        public PokemonDBContext()
        {
        }

        public PokemonDBContext(DbContextOptions<PokemonDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<Highscore> Highscores { get; set; }
        public virtual DbSet<PokemonCard> PokemonCards { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:pokemontiimi.database.windows.net,1433;Initial Catalog=PokemonDB;Persist Security Info=False;User ID=TeamPokemon;Password=Ryhmä1voittaa!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OtherUser).HasColumnName("other_user");

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.OtherUserNavigation)
                    .WithMany(p => p.ConnectionOtherUserNavigations)
                    .HasForeignKey(d => d.OtherUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Connections_User1");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.ConnectionUserNavigations)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Connections_User");
            });

            modelBuilder.Entity<Highscore>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Losses).HasColumnName("losses");

                entity.Property(e => e.User).HasColumnName("user");

                entity.Property(e => e.Victories).HasColumnName("victories");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Highscores)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Highscores_User");
            });

            modelBuilder.Entity<PokemonCard>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PokemonId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pokemon_id");

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.PokemonCards)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PokemonCards_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cash).HasColumnName("cash");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Xp).HasColumnName("xp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
