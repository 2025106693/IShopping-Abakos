using System.Collections.Generic;

namespace iShopping_Abakos.Model
{
    //Representa uma categoria ou tipo de artigo
    internal class TipoArtigo
    {
        //Identificador único do Tipo de Artigo
        public int Id { get; set; }

        //Nome do Tipo de Artigo 
        public string Nome { get; set; }

        //Descrição do Tipo de Artigo
        public string Descricao { get; set; }

        //Propriedade de navegação que permite aceder
        //a todos os artigos associados a este tipo de artigo
        public virtual ICollection<Artigo> Artigos { get; set; } = new List<Artigo>();

    }
}
