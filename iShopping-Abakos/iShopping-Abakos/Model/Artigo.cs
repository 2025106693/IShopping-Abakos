using iShopping_Abakos.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace iShopping_Abakos
{
    // Classe dos Artigo (ex: detergente, sabonete, etc)
    internal class Artigo
    {
        // Id, chave primária
        public int Id { get; set; }

        // Nome do artigo (não pode haver dois artigos com o mesmo nome)
        public string Nome { get; set; }

        // Preço base
        public decimal Preco { get; set; }

        // Descrição opcional
        public string Descricao { get; set; }

        // FK que diz a que tipo este artigo pertence
        public int TipoArtigoId { get; set; }// Coluna real da tabela guarda o id do tipoArtigo

        // Propriedade de navegação (lado "um" para muitos)
        // Permite aceder ao TipoArtigo todo, ex: artigo.TipoArtigo.Nome
        public virtual TipoArtigo TipoArtigo { get; set; }  //a propriedade de navegação, o atalho para o objeto tipo completo

    }
}




