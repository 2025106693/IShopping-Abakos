using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    internal class ResumoEstatisticas
    {
        public SugestaoOrcamento SugestaoOrcamentos { get; set; }

        public List<HistoricoOrcamentoDataGridView> HistoricoOrcamentos { get; set; }

        public List<PercentagemArtigosDataGridView> PercentagensArtigos { get; set; }
        
    }
}
