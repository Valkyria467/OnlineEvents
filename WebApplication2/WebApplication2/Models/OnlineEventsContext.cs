using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class OnlineEventsContext : DbContext
    {
        public OnlineEventsContext()
        {
        }

        public OnlineEventsContext(DbContextOptions<OnlineEventsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Access> Access { get; set; }
        public virtual DbSet<Decor> Decor { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventUsers> EventUsers { get; set; }
        public virtual DbSet<Leader> Leader { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<RoleUser> RoleUser { get; set; }
        public virtual DbSet<TypeEvent> TypeEvent { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=WIN-27L6NAINRRS;Initial Catalog=OnlineEvents;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>(entity =>
            {
                entity.HasKey(e => e.IdAccess);

                entity.Property(e => e.IdAccess).HasColumnName("idAccess");

                entity.Property(e => e.NameAccess)
                    .IsRequired()
                    .HasColumnName("nameAccess")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Decor>(entity =>
            {
                entity.HasKey(e => e.IdDecor);

                entity.Property(e => e.IdDecor).HasColumnName("idDecor");

                entity.Property(e => e.NameDecor)
                    .IsRequired()
                    .HasColumnName("nameDecor")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SurnameDecor)
                    .IsRequired()
                    .HasColumnName("surnameDecor")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.IdEvent);

                entity.Property(e => e.IdEvent).HasColumnName("idEvent");

                entity.Property(e => e.Access).HasColumnName("access");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("smallmoney");

                entity.Property(e => e.DateEvent)
                    .HasColumnName("dateEvent")
                    .HasColumnType("datetime");

                entity.Property(e => e.Decor).HasColumnName("decor");

                entity.Property(e => e.House)
                    .HasColumnName("house")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Leader).HasColumnName("leader");

                entity.Property(e => e.NameEvent)
                    .IsRequired()
                    .HasColumnName("nameEvent")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Organizer).HasColumnName("organizer");

                entity.Property(e => e.Place).HasColumnName("place");

                entity.Property(e => e.Sreet)
                    .IsRequired()
                    .HasColumnName("sreet")
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.Property(e => e.TypeEvent).HasColumnName("typeEvent");

                entity.HasOne(d => d.AccessNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Access)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__access__68487DD7");

                entity.HasOne(d => d.DecorNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Decor)
                    .HasConstraintName("FK__Event__decor__6B24EA82");

                entity.HasOne(d => d.LeaderNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Leader)
                    .HasConstraintName("FK__Event__leader__693CA210");

                entity.HasOne(d => d.OrganizerNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Organizer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__organizer__6754599E");

                entity.HasOne(d => d.PlaceNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Place)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__place__6A30C649");

                entity.HasOne(d => d.TypeEventNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.TypeEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__typeEvent__66603565");
            });

            modelBuilder.Entity<EventUsers>(entity =>
            {
                entity.HasKey(e => e.IdEu);

                entity.Property(e => e.IdEu).HasColumnName("idEU");

                entity.Property(e => e.IdEvent).HasColumnName("idEvent");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.EventUsers)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventUser__idEve__6EF57B66");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.EventUsers)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventUser__idUse__6E01572D");
            });

            modelBuilder.Entity<Leader>(entity =>
            {
                entity.HasKey(e => e.IdLeader);

                entity.Property(e => e.IdLeader).HasColumnName("idLeader");

                entity.Property(e => e.NameLeader)
                    .IsRequired()
                    .HasColumnName("nameLeader")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SurnameLeader)
                    .IsRequired()
                    .HasColumnName("surnameLeader")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.IdPhoto);

                entity.Property(e => e.IdPhoto).HasColumnName("idPhoto");

                entity.Property(e => e.NamePhoto)
                    .IsRequired()
                    .HasColumnName("namePhoto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SurnamePhoto)
                    .IsRequired()
                    .HasColumnName("surnamePhoto")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasKey(e => e.IdPlace);

                entity.Property(e => e.IdPlace).HasColumnName("idPlace");

                entity.Property(e => e.NamePlace)
                    .IsRequired()
                    .HasColumnName("namePlace")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.NameRole)
                    .IsRequired()
                    .HasColumnName("nameRole")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeEvent>(entity =>
            {
                entity.HasKey(e => e.IdType);

                entity.Property(e => e.IdType).HasColumnName("idType");

                entity.Property(e => e.NameType)
                    .IsRequired()
                    .HasColumnName("nameType")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.LoginUser)
                    .IsRequired()
                    .HasColumnName("loginUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameUser)
                    .IsRequired()
                    .HasColumnName("nameUser")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordUser)
                    .IsRequired()
                    .HasColumnName("passwordUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleUser).HasColumnName("roleUser");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleUserNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__roleUser__3B75D760");
            });
        }
    }
}
