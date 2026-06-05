using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    internal class HistoricoOrcamentoDataGridView
    {
        public int Ano { get; set; }

        public string Mes { get; set; }

        public decimal Orcamento { get; set; }

        public decimal TotalCompras { get; set; }

        public decimal Diferenca { get; set; }

    }
}
