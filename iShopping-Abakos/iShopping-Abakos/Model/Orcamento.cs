using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos
{
    //Representa um orçamento definido para um determinado mês
    internal class Orcamento
    {
        //Identificador único do orçamento
        public int Id { get; set; }

        //Mês a que o orçamento se refere
        public string Mes { get; set; }

        //Ano a que o orçamento se refere
        public int Ano { get; set; }

        //Valor definido para o orçamento
        public decimal Valor { get; set; }

        //Os seguintes campos contêm o registo de quem efetuou ações
        //sobre o orçamento e as respetivas datas

        //Utilizador que criou o orçamento
        public string CriadoPor { get; set; }
        public DateTime DataCriacao { get; set; } //data de criação

        //Utilizador que alterou o orçamento
        public string AlteradoPor { get; set; }
        public DateTime? DataAlteracao { get; set; } //data de alteração

    }
}

