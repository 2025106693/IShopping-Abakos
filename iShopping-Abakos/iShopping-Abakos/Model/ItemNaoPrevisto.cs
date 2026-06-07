using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    //Representa um artigo que foi adicionado a uma compra
    //sem ter sido previamente planeado/previsto
    //(adicionado a partir do "Modo Compra" = Visualizar Detalhes --> Gerir Item Não Previsto
    [Table("DBItensNaoPrevistos")]

    //Herda da classe ItemCompra, reutilizando os seus atributos
    //e adicionando a quantidade prevista para o artigo
    internal class ItemNaoPrevisto : ItemCompra
    {
        //Observacoes do artigo que não foi previamente planeado
        public string Observacoes { get; set; }

    }


}
