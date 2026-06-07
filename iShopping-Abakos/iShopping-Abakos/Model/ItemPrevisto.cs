using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    //Representa um artigo que foi adicionado a uma compra
    //e que foi previamente planeado/previsto
    //(adicionado a partir da criação de uma compra) Compra ---> Adicionar/Editar Itens

    //Mapeia a entidade ItemPrevisto para a tabela DBItensPrevistos
    [Table("DBItensPrevistos")]

    //Herda da classe ItemCompra, reutilizando os seus atributos
    //e adicionando a quantidade prevista para o artigo
    internal class ItemPrevisto : ItemCompra
    {
        //Quantidade prevista para aquisição do artigo
        public int QuantPrevista { get; set; }

    }
}
