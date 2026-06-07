using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    //Representa um artigo que foi adicionado a uma compra,
    //contendo a informação comum aos itens previstos e não previstos
    internal class ItemCompra
    {
        //Identificador único do item da compra
        public int Id { get; set; }

        //Quantidade adquirida do artigo
        public int Quantidade { get; set; }

        //Preco unitário do artigo
        public decimal PrecoUnitario { get; set; }

        //Foreign Key que identifica a compra associada
        public int CompraId { get; set; }

        //public virtual Compra Compra { get; set; } // propriedade de navegação
        //que permite aceder à compra associada ao item

        //Foreign Key que identifica o artigo associado
        public int ArtigoId { get; set; }

        public virtual Artigo Artigo { get; set; } // propriedade de navegação
        // que permite aceder ao artigo associado ao item
    }
}
