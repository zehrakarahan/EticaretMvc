namespace ZeonTicaretWebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UrunOzellikleri")]
    public partial class UrunOzellikleri
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UrunId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OzellikTipi { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OzellikDegerId { get; set; }

        public virtual OzellikDegeri OzellikDegeri { get; set; }

        public virtual OzellikTip OzellikTip { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
