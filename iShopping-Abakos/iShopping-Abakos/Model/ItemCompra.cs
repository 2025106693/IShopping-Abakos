using System;
using System.Collections.Generic;
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

        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        
        public virtual Compra Compra { get; set; }
        public virtual Artigo Artigo { get; set; }

    }
}
