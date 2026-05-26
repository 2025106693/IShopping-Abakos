using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos
{
    internal class Orcamento
    {
        public int Id { get; set; }
        public string Mes { get; set; }
        public int Ano { get; set; }

        public decimal Valor { get; set; }
        public string CriadoPor { get; set; }
        public DateTime DataCriacao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime? DataAlteracao { get; set; }
        
        

    }
}
