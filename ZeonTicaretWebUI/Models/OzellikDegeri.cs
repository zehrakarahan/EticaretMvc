namespace ZeonTicaretWebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OzellikDegeri")]
    public partial class OzellikDegeri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OzellikDegeri()
        {
            UrunOzellikleri = new HashSet<UrunOzellikleri>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public int? OzellikTipId { get; set; }

        public virtual OzellikTip OzellikTip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunOzellikleri> UrunOzellikleri { get; set; }
    }
}
