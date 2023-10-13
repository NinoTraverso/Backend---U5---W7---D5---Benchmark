namespace Inforno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodotti")]
    public partial class Prodotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodotti()
        {
            Dettagli = new HashSet<Dettagli>();
        }

        [Key]
        public int IdProdotto { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(5)]
        public string Foto { get; set; }

        public int Costo { get; set; }

        public int Preparazione { get; set; }

        [Required]
        [StringLength(50)]
        public string Ingredienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dettagli> Dettagli { get; set; }
    }
}
