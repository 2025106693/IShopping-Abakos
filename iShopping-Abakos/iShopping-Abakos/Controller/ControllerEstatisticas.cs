using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerEstatisticas
    {
        public static void VoltarPaginaPrincipal()
        {
            EstatisticasForm.instance.Close();
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
        }

        public static SugestaoOrcamento SugerirOrcamento(out string mensagem)
        {
            Dictionary<string, int> meses = new Dictionary<string, int>
                {
                    { "Janeiro", 1 },
                    { "Fevereiro", 2 },
                    { "Março", 3 },
                    { "Abril", 4 },
                    { "Maio", 5 },
                    { "Junho", 6 },
                    { "Julho", 7 },
                    { "Agosto", 8 },
                    { "Setembro", 9 },
                    { "Outubro", 10 },
                    { "Novembro", 11 },
                    { "Dezembro", 12 }
                };

            mensagem = "";

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

                   mensagem = "Sugestões de orçamentos geradas com sucesso!";
                }

                else
                {
                    mensagem = "Não foi possível calcular as estatísticas de orçamento! Verifique se tem orçamentos!";
                    return null;
                }

                return sugestao;
            }
        }

        public static void MostrarHistoricoOrcamento()
        {

            Dictionary<string, int> meses = new Dictionary<string, int>
                {
                    { "Janeiro", 1 },
                    { "Fevereiro", 2 },
                    { "Março", 3 },
                    { "Abril", 4 },
                    { "Maio", 5 },
                    { "Junho", 6 },
                    { "Julho", 7 },
                    { "Agosto", 8 },
                    { "Setembro", 9 },
                    { "Outubro", 10 },
                    { "Novembro", 11 },
                    { "Dezembro", 12 }
                };

            using (IShoppingContext db = new IShoppingContext())
            {
                var orcamentos = db.DBOrcamentos
                                   .AsEnumerable()                       // a partir daqui é em memória
                                   .OrderByDescending(o => o.Ano)
                                   .ThenByDescending(o => meses[o.Mes])  // agora o dicionário funciona
                                   .Select(o => new
                                   {
                                       o.Ano,
                                       o.Mes,
                                       o.Valor
                                   })
                                   .ToList();                           

                if (orcamentos != null)
                {
                    EstatisticasForm.historicoOrcamentos.DataSource = orcamentos;
                }

                else
                {
                    MessageBox.Show("Sem orçamentos para apresentar");
                    return;
                }
            }
        }
    }
}
