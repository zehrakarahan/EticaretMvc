namespace ZeonTicaretWebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Satis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Satis()
        {
            SatisDetay = new HashSet<SatisDetay>();
        }

        public int Id { get; set; }

        public int? MusteriId { get; set; }

        public DateTime SatisTarihi { get; set; }

        [Column(TypeName = "money")]
        public decimal? Toplamtutar { get; set; }

        public bool? Sepettemi { get; set; }

        public int? KargoId { get; set; }

        public int? SiparisDurumId { get; set; }

        [StringLength(15)]
        public string KargotakipNo { get; set; }

        public virtual Kargo Kargo { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual SiparisDurum SiparisDurum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatisDetay> SatisDetay { get; set; }
    }
}
