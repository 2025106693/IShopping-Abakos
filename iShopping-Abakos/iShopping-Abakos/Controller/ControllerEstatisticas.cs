using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace iShopping_Abakos.Controller
{
    internal class ControllerEstatisticas
    {
        public static void VoltarPaginaPrincipal()
        {
            EstatisticasForm.instance.Close();
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
        }

        public static SugestaoOrcamento SugerirOrcamento()
        {
            var meses = ControllerOrcamento.DevolverIntMesCorrespondente();


            SugestaoOrcamento sugestao = new SugestaoOrcamento();

            using (IShoppingContext db = new IShoppingContext())
            {
                DateTime dataMin = DateTime.Now.AddMonths(-6);

                var orcamentos = db.DBOrcamentos
                                   .ToList()
                                   .Where(o => new DateTime(o.Ano, meses[o.Mes], 1) >= dataMin
                                            && new DateTime(o.Ano, meses[o.Mes], 1) < DateTime.Today)
                                   .ToList();

                if (orcamentos != null)
                {
                    sugestao.MediaUltimosMeses = orcamentos.Average(o => o.Valor);
                    sugestao.SugestaoProximoMes = sugestao.MediaUltimosMeses;

                    MessageBox.Show("Sugestões de orçamentos geradas com sucesso!");
                }

                else
                {
                    MessageBox.Show("Não foi possível calcular as estatísticas de orçamento! Verifique se tem orçamentos!");
                    return null;
                }

                return sugestao;
            }
        }

        public static List<HistoricoOrcamentoDataGridView> MostrarHistoricoOrcamento()
        {

            var meses = ControllerOrcamento.DevolverIntMesCorrespondente();

            using (IShoppingContext db = new IShoppingContext())
            {
                
                HistoricoOrcamentoDataGridView historicoOrcamentos = new HistoricoOrcamentoDataGridView();

                var orcamentos = db.DBOrcamentos
                                .AsEnumerable()     // como a base de dados nao reconhece dicionarios, temos que fazer do lado da maquina e nao da base de dados
                                .Select(o =>
                                {
                                    int mesNumero = meses[o.Mes];

                                    decimal totalCompras = db.DBCompras
                                        .Where(c =>
                                            c.DataFecho.Value.Year == o.Ano &&
                                            c.DataFecho.Value.Month == mesNumero)
                                        .Sum(c => (decimal?)c.TotalGasto) ?? 0;

                                    return new HistoricoOrcamentoDataGridView
                                    {
                                        Ano = o.Ano,
                                        Mes = o.Mes,
                                        Orcamento = o.Valor,
                                        TotalCompras = totalCompras,
                                        Diferenca = o.Valor - totalCompras
                                    };
                                })
                                .ToList();

                if (orcamentos != null)
                {
                    EstatisticasForm.historicoOrcamentos.DataSource = orcamentos;
                    return orcamentos;

                }

                else
                {
                    MessageBox.Show("Sem orçamentos para apresentar");
                    return null;
                }
            }
        }



        public static List<PercentagemArtigosDataGridView> MostrarEstatisticasArtigos()
        {
            using(IShoppingContext db = new IShoppingContext())
            {
                PercentagemArtigosDataGridView percentagemArtigos = new PercentagemArtigosDataGridView();

                var comprasFechadas = db.DBCompras
                        .Where(c => c.Fechado)
                        .ToList()
                        .Select(compra =>
                        {
                            int previstos = db.DBItensCompra.OfType<ItemPrevisto>()
                                .Count(i => i.CompraId == compra.Id);

                            int naoPrevistos = db.DBItensCompra.OfType<ItemNaoPrevisto>()
                                .Count(i => i.CompraId == compra.Id);

                            int total = previstos + naoPrevistos;

                            return new PercentagemArtigosDataGridView
                            {
                                Compra = compra.NomeCompra,
                                PercentagemPrevistos = total == 0 ? 0 : (decimal)previstos * 100 / total,
                                PercentagemNaoPrevistos = total == 0 ? 0 : (decimal)naoPrevistos * 100 / total
                            };
                        })
                        .ToList();

                

                if (comprasFechadas == null)
                {
                    MessageBox.Show("Um erro ocorreu. Não foi possível gerir estatísticas!");
                    return null;
                }

                else 
                { 
                    EstatisticasForm.ListagemPercentagem.DataSource = comprasFechadas;
                    return comprasFechadas;
                }
            }

            
        }
        public static void ExportarEstatisticasCsv(string caminho)
        {
            ResumoEstatisticas resumo = ObterResumoEstatisticas();

            using (StreamWriter sw = new StreamWriter(caminho, false))
            {
                 sw.WriteLine(
                        "Média últimos meses;" + resumo.SugestaoOrcamentos.MediaUltimosMeses + ";" +
                        "Sugestão próximo mês;" + resumo.SugestaoOrcamentos.SugestaoProximoMes + ";");


                sw.WriteLine();
                sw.WriteLine("Histórico de Orçamentos");
                sw.WriteLine("Ano;Mês;Orçamento;Total Compras;Diferença");

                foreach (var item in resumo.HistoricoOrcamentos)
                {
                    sw.WriteLine(
                        item.Ano + ";" +
                        item.Mes + ";" +
                        item.Orcamento + ";" +
                        item.TotalCompras + ";" +
                        item.Diferenca);
                }

                sw.WriteLine();
                sw.WriteLine("Percentagem de Artigos");
                sw.WriteLine("Compra;Previstos;Não Previstos");

                foreach (var item in resumo.PercentagensArtigos)
                {
                    sw.WriteLine(
                        item.Compra + ";" +
                        item.PercentagemPrevistos + ";" +
                        item.PercentagemNaoPrevistos);
                }
            }
        }

        public static ResumoEstatisticas ObterResumoEstatisticas()
        {
            ResumoEstatisticas resumo = new ResumoEstatisticas();


            resumo.SugestaoOrcamentos = SugerirOrcamento();
            resumo.HistoricoOrcamentos = MostrarHistoricoOrcamento();
            resumo.PercentagensArtigos = MostrarEstatisticasArtigos();

            return resumo;
        }


    }
}
