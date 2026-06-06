using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    [Table("DBItemCompras")]
    internal abstract class ItemCompra
    {

        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public int CompraId { get; set; }

        public virtual Compra Compra { get; set; }

        public int ArtigoId { get; set; }
        public virtual Artigo Artigo { get; set; }

    }
}
