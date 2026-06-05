using iShopping_Abakos.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace iShopping_Abakos
{
    internal class Artigo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public string Descricao { get; set; }

        //Foreign Key que identifica o tipo de artigo associado
        [ForeignKey("TipoArtigo")] 

        public int TipoArtigoId { get; set; }

        public virtual TipoArtigo TipoArtigo { get; set; } //a propriedade de navegação
                                                           //permite aceder ao objeto TipoArtigo associado ao artigo

        public virtual ICollection<ItemCompra> ItensCompra { get; set; } = new List<ItemCompra>(); //propriedade de navegação,
                                                                                                   //permite aceder a todos os itens de compra que utilizam este artigo
                                                                                                    
    }
}





