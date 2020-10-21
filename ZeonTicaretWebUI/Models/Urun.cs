namespace ZeonTicaretWebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urun()
        {
            Resim = new HashSet<Resim>();
            SatisDetay = new HashSet<SatisDetay>();
            UrunOzellikleri = new HashSet<UrunOzellikleri>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Aciklama { get; set; }

        [Column(TypeName = "money")]
        public decimal? AlisFiyati { get; set; }

        [Column(TypeName = "money")]
        public decimal? SatisFiyati { get; set; }

        public DateTime? EklenmeTarihi { get; set; }

        [StringLength(10)]
        public string SonKullanmaTarihi { get; set; }

        public int? KategoriId { get; set; }

        public int? MarkaID { get; set; }

        public int? ResimID { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Marka Marka { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resim> Resim { get; set; }

        public virtual Resim Resim1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatisDetay> SatisDetay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunOzellikleri> UrunOzellikleri { get; set; }
    }
}
