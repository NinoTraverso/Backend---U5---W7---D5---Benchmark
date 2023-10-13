using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Inforno.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Dettagli> Dettagli { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordini>()
                .HasMany(e => e.Dettagli)
                .WithRequired(e => e.Ordini)
                .HasForeignKey(e => e.OrdineID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.Dettagli)
                .WithRequired(e => e.Prodotti)
                .HasForeignKey(e => e.ProdottoID)
                .WillCascadeOnDelete(false);
        }
    }
}
