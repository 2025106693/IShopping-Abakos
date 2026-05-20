using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iShopping_Abakos
{
    internal class TipoArtigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        
        //Um TipoArtigo tem vários Artigos --> Coleção
        public virtual ICollection<Artigo> Artigos { get; set; }
        
    }
}
