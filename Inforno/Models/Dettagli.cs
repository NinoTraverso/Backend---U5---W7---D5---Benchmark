namespace Inforno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dettagli")]
    public partial class Dettagli
    {
        [Key]
        public int IdDettaglio { get; set; }

        public int ProdottoID { get; set; }

        public int Quantita { get; set; }

        public int OrdineID { get; set; }

        public virtual Ordini Ordini { get; set; }

        public virtual Prodotti Prodotti { get; set; }
    }
}
