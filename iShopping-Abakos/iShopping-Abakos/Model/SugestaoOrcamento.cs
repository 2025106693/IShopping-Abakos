using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    //Representa uma sugestão de orçamento calculada
    //com base nos últimos 6 meses
    internal class SugestaoOrcamento
    {
        //valor médio de orçamentos nos últimos 6 meses

        public decimal MediaUltimosMeses { get; set; }

        //valor sugerido para o orçamento do próximo mês
        public decimal SugestaoProximoMes { get; set; }
    }
}
