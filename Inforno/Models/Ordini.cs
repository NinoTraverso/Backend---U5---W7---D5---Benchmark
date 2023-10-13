namespace Inforno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordini()
        {
            Dettagli = new HashSet<Dettagli>();
        }

        [Key]
        public int IdOrdine { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeCliente { get; set; }

        [Required]
        [StringLength(50)]
        public string Indirizzo { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataOrdine { get; set; }

        [Required]
        [StringLength(50)]
        public string Nota { get; set; }

        public int Totale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dettagli> Dettagli { get; set; }
    }
}
