namespace ZeonTicaretWebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resim()
        {
            Kategori = new HashSet<Kategori>();
            Marka = new HashSet<Marka>();
            Urun1 = new HashSet<Urun>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Buyukyol { get; set; }

        [StringLength(250)]
        public string Ortayol { get; set; }

        [StringLength(250)]
        public string Kucukyol { get; set; }

        public bool? Varsayilan { get; set; }

        public byte? SiraNo { get; set; }

        public int? UrunId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kategori> Kategori { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Marka> Marka { get; set; }

        public virtual Urun Urun { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urun> Urun1 { get; set; }
    }
}
