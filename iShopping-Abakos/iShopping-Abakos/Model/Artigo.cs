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

        // FK  -> aponta para TipoArtigo.Id Por convenção vai ao nome da navegação TipoArtigo + Id
        // [ForeignKey("TipoArtigo")] // Diz que o "TipoArtigo" é a FK 

        public int TipoArtigoId { get; set; } // Coluna real da tabela guarda o id do tipoArtigo
        // Propriedade de navegação (lado "um" para muitos)
        public virtual TipoArtigo TipoArtigo { get; set; } //a propriedade de navegação, o atalho para o objeto tipo completo

    }
}




