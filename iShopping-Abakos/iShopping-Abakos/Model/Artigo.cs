using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos
{
    internal class Artigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public string Descricao { get; set; }


        [ForeignKey("TipoArtigo")]
        // FK real -> aponta para TipoArtigo.Id
        public int IdTipoArtigo { get; set; }

        // Propriedade de navegação (lado "um" para muitos)
        // tem de conter o mesmo nome que a tabela TipoArtigo
        public virtual TipoArtigo TipoArtigo { get; set; }

        //FK
        //public string TipoArtigo { get; set ; }

        //Lado "muitos" da relação com TipoArtigo

        // public virtual ICollection<ItemCompra> ItensCompra { get; set; }

        
    }
}




