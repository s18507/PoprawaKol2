using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class s18507Context : DbContext
    {
        public s18507Context()
        {
        }

        public s18507Context(DbContextOptions<s18507Context> options)
            : base(options)
        {
        }

       
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistEvent> ArtistEvent { get; set; }
       
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventOrganiser> EventOrganiser { get; set; }
        
        public virtual DbSet<Organiser> Organiser { get; set; }
       
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.IdArtist)
                    .HasName("Artist_pk");

                entity.Property(e => e.IdArtist).ValueGeneratedNever();

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ArtistEvent>(entity =>
            {
                entity.HasKey(e => new { e.ArtistIdArtist, e.EventIdEvent })
                    .HasName("Artist_Event_pk");

                entity.ToTable("Artist_Event");

                entity.Property(e => e.ArtistIdArtist).HasColumnName("Artist_IdArtist");

                entity.Property(e => e.EventIdEvent).HasColumnName("Event_IdEvent");

                entity.HasOne(d => d.ArtistIdArtistNavigation)
                    .WithMany(p => p.ArtistEvent)
                    .HasForeignKey(d => d.ArtistIdArtist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Artist_Event_Artist");

                entity.HasOne(d => d.EventIdEventNavigation)
                    .WithMany(p => p.ArtistEvent)
                    .HasForeignKey(d => d.EventIdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Artist_Event_Event");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.IdEvent)
                    .HasName("Event_pk");

                entity.Property(e => e.IdEvent).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EventOrganiser>(entity =>
            {
                entity.HasKey(e => new { e.EventIdEvent, e.OrganiserIdOrganiser })
                    .HasName("Event_Organiser_pk");

                entity.ToTable("Event_Organiser");

                entity.Property(e => e.EventIdEvent).HasColumnName("Event_IdEvent");

                entity.Property(e => e.OrganiserIdOrganiser).HasColumnName("Organiser_IdOrganiser");

                entity.HasOne(d => d.EventIdEventNavigation)
                    .WithMany(p => p.EventOrganiser)
                    .HasForeignKey(d => d.EventIdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Event_Organiser_Event");

                entity.HasOne(d => d.OrganiserIdOrganiserNavigation)
                    .WithMany(p => p.EventOrganiser)
                    .HasForeignKey(d => d.OrganiserIdOrganiser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Event_Organiser_Organiser");
            });

            modelBuilder.Entity<Organiser>(entity =>
            {
                entity.HasKey(e => e.IdOrganiser)
                    .HasName("Organiser_pk");

                entity.Property(e => e.IdOrganiser).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
