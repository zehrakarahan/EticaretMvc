namespace ZeonTicaretWebUI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MvcDB : DbContext
    {
        public MvcDB()
            : base("name=MvcDB1")
        {
        }

        public virtual DbSet<Kargo> Kargo { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<MusteriAdres> MusteriAdres { get; set; }
        public virtual DbSet<OzellikDegeri> OzellikDegeri { get; set; }
        public virtual DbSet<OzellikTip> OzellikTip { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<Satis> Satis { get; set; }
        public virtual DbSet<SatisDetay> SatisDetay { get; set; }
        public virtual DbSet<SiparisDurum> SiparisDurum { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<UrunOzellikleri> UrunOzellikleri { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kargo>()
                .Property(e => e.Telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.OzellikTip)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.Telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.MusteriAdres)
                .WithRequired(e => e.Musteri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OzellikDegeri>()
                .HasMany(e => e.UrunOzellikleri)
                .WithRequired(e => e.OzellikDegeri)
                .HasForeignKey(e => e.OzellikDegerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OzellikTip>()
                .HasMany(e => e.UrunOzellikleri)
                .WithRequired(e => e.OzellikTip)
                .HasForeignKey(e => e.OzellikTipi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resim>()
                .HasMany(e => e.Urun1)
                .WithOptional(e => e.Resim1)
                .HasForeignKey(e => e.ResimID);

            modelBuilder.Entity<Satis>()
                .Property(e => e.Toplamtutar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Satis>()
                .HasMany(e => e.SatisDetay)
                .WithRequired(e => e.Satis)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SatisDetay>()
                .Property(e => e.Fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urun>()
                .Property(e => e.AlisFiyati)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urun>()
                .Property(e => e.SatisFiyati)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urun>()
                .Property(e => e.SonKullanmaTarihi)
                .IsFixedLength();

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.Resim)
                .WithOptional(e => e.Urun)
                .HasForeignKey(e => e.UrunId);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.SatisDetay)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.UrunOzellikleri)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);
        }
    }
}
