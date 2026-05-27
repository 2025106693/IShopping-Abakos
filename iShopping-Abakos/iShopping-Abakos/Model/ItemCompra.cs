using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    internal class ItemCompra
    {

        public int Id { get; set; }

        // FK - PK composta
        public int IdCompra { get; set; }
        public int IdArtigo { get; set; }

        //FK
        public int IdCriadoPor { get; set; }
        public int? IdAlteradoPor { get; set; }

        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        /*[ForeignKey("Compra")]

        public int CompraId { get; set; }
        public virtual Compra compra { get; set; }

        [ForeignKey("Artigo")]
        public int ArtigoId { get; set; }
        public virtual Artigo artigo { get; set; }*/

    }
}
