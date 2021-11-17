using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eDecor.WebAPI.Database
{
    public partial class eDecorContext : DbContext
    {
        public eDecorContext()
        {
        }

        public eDecorContext(DbContextOptions<eDecorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artikli> Artikli { get; set; }
        public virtual DbSet<Drzave> Drzave { get; set; }
        public virtual DbSet<Gradovi> Gradovi { get; set; }
        public virtual DbSet<Kategorije> Kategorije { get; set; }
        public virtual DbSet<Klijenti> Klijenti { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual DbSet<Notifikacije> Notifikacije { get; set; }
        public virtual DbSet<Ocjene> Ocjene { get; set; }
        public virtual DbSet<Podkategorije> Podkategorije { get; set; }
        public virtual DbSet<Popusti> Popusti { get; set; }
        public virtual DbSet<Pretplate> Pretplate { get; set; }
        public virtual DbSet<Rezervacije> Rezervacije { get; set; }
        public virtual DbSet<RezervacijeArtikli> RezervacijeArtikli { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=eDecor;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikli>(entity =>
            {
                entity.HasKey(e => e.ArtikalId);

                entity.Property(e => e.ArtikalId).HasColumnName("ArtikalID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(200);

                entity.Property(e => e.PodkategorijaId).HasColumnName("PodkategorijaID");

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Artikli)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Artikli_Kategorije");

                entity.HasOne(d => d.Podkategorija)
                    .WithMany(p => p.Artikli)
                    .HasForeignKey(d => d.PodkategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Artikli_Podkategorije");
            });

            modelBuilder.Entity<Drzave>(entity =>
            {
                entity.HasKey(e => e.DrzavaId);

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gradovi>(entity =>
            {
                entity.HasKey(e => e.GradId);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Gradovi)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gradovi_Drzave");
            });

            modelBuilder.Entity<Kategorije>(entity =>
            {
                entity.HasKey(e => e.KategorijaId);

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(200);
            });

            modelBuilder.Entity<Klijenti>(entity =>
            {
                entity.HasKey(e => e.KlijentId);

                entity.HasIndex(e => e.Email)
                    .HasName("Klijenti_Email")
                    .IsUnique();

                entity.HasIndex(e => e.KorisnickoIme)
                    .HasName("Klijenti_KorisnickoIme")
                    .IsUnique();

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.DatumRegistracije).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Klijenti)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Klijenti_Gradovi");
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.KorisnikId);

                entity.HasIndex(e => e.Email)
                    .HasName("Korisnici_Email")
                    .IsUnique();

                entity.HasIndex(e => e.KorisnickoIme)
                    .HasName("Korisnici_KorisnickoIme")
                    .IsUnique();

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LozinkaSalt).HasMaxLength(500);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefon).HasMaxLength(20);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Korisnici)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnici_Gradovi");
            });

            modelBuilder.Entity<KorisniciUloge>(entity =>
            {
                entity.HasKey(e => e.KorisnikUlogaId);

                entity.Property(e => e.KorisnikUlogaId).HasColumnName("KorisnikUlogaID");

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Korisnici");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Uloge");
            });

            modelBuilder.Entity<Notifikacije>(entity =>
            {
                entity.HasKey(e => e.NotifikacijaId);

                entity.Property(e => e.NotifikacijaId).HasColumnName("NotifikacijaID");

                entity.Property(e => e.DatumSlanja).HasColumnType("datetime");

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sadrzaj).IsRequired();

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Notifikacije)
                    .HasForeignKey(d => d.KlijentId)
                    .HasConstraintName("FK_Notifikacije_Klijenti");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Notifikacije)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Novosti_Korisnici");
            });

            modelBuilder.Entity<Ocjene>(entity =>
            {
                entity.HasKey(e => e.OcjenaId);

                entity.Property(e => e.OcjenaId).HasColumnName("OcjenaID");

                entity.Property(e => e.ArtikalId).HasColumnName("ArtikalID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.HasOne(d => d.Artikal)
                    .WithMany(p => p.Ocjene)
                    .HasForeignKey(d => d.ArtikalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocjene_Atrikli");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Ocjene)
                    .HasForeignKey(d => d.KlijentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocjene_Klijenti");
            });

            modelBuilder.Entity<Podkategorije>(entity =>
            {
                entity.HasKey(e => e.PodkategorijaId);

                entity.Property(e => e.PodkategorijaId).HasColumnName("PodkategorijaID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(200);

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Podkategorije)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Podkategorije_Kategorije");
            });

            modelBuilder.Entity<Popusti>(entity =>
            {
                entity.HasKey(e => e.PopustId);

                entity.HasIndex(e => e.Kod)
                    .HasName("Popust_PopustKod")
                    .IsUnique();

                entity.Property(e => e.PopustId).HasColumnName("PopustID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Kod).HasMaxLength(100);

                entity.Property(e => e.Popust).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Pretplate>(entity =>
            {
                entity.HasKey(e => e.PretplataId);

                entity.Property(e => e.PretplataId).HasColumnName("PretplataID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Pretplate)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preplate_Kategorije");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Pretplate)
                    .HasForeignKey(d => d.KlijentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preplate_Klijenti");
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.HasKey(e => e.RezervacijaId);

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.Adresa).HasMaxLength(200);

                entity.Property(e => e.DatumKreiranja).HasColumnType("datetime");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Napomena).HasMaxLength(200);

                entity.Property(e => e.IznosAvansnogPlacanje).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PopustId).HasColumnName("PopustID");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rezervacije_Gradovi");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.KlijentId)
                    .HasConstraintName("FK_Rezervacije_Klijenti");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Rezervacije_Korisnici");

                entity.HasOne(d => d.Popust)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.PopustId)
                    .HasConstraintName("FK_Rezervacije_Popusti");
            });

            modelBuilder.Entity<RezervacijeArtikli>(entity =>
            {
                entity.HasKey(e => e.RezervacijaArtikalId);

                entity.Property(e => e.RezervacijaArtikalId).HasColumnName("RezervacijaArtikalID");

                entity.Property(e => e.ArtikalId).HasColumnName("ArtikalID");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.HasOne(d => d.Artikal)
                    .WithMany(p => p.RezervacijeArtikli)
                    .HasForeignKey(d => d.ArtikalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RezervacijeArtikli_Artikli");

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.RezervacijeArtikli)
                    .HasForeignKey(d => d.RezervacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RezervacijeArtikli_Rezervacije");
            });

            modelBuilder.Entity<Uloge>(entity =>
            {
                entity.HasKey(e => e.UlogaId);

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
