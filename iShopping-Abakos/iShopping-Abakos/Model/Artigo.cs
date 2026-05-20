using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos
{
    internal class Artigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        // FK
        public int IdTipoArtigo { get; set; }

        //Lado "muitos" da relação com TipoArtigo
        public virtual ICollection<ItemCompra> ItensCompra { get; set; }
    }
}
