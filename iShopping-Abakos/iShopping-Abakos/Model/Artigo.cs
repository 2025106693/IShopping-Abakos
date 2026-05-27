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


        [ForeignKey("TipoArtigo")] // nome da propriedade a baixo

        // FK  -> aponta para TipoArtigo.Id Por convenção vai ao nome da navegação TipoArtigo + Id
        public int TipoArtigoId { get; set; }
        // Propriedade de navegação (lado "um" para muitos)
        public virtual TipoArtigo TipoArtigo { get; set; }
    
    }
}




