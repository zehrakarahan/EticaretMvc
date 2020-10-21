namespace ZeonTicaretWebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MusteriAdres
    {
        public int Id { get; set; }

        public int MusteriID { get; set; }

        [Required]
        [StringLength(500)]
        public string Adres { get; set; }

        public int AdresTipiId { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
