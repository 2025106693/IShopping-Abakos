using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    //Controller responsável pelas Estatísticas
    internal class ControllerEstatisticas
    {
        //Fecha o formulário de estatísticas e volta à página principal.
        public static void VoltarPaginaPrincipal()
        {
            EstatisticasForm.instance.Close();
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
        }

        //Calcula a sugestão de orçamento com base na média dos últimos 6 meses
        public static SugestaoOrcamento SugerirOrcamento(out string mensagem)
        {
            //Dicionário que converte o nome do mês (string) no número correspondente
            var meses = ControllerOrcamento.DevolverIntMesCorrespondente();

            mensagem = "";

            //Cria uma nova instância da classe Sugestão que contém os atributos
            //média e sugestão
            
            SugestaoOrcamento sugestao = new SugestaoOrcamento();

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Obtém a data limite: apenas os orçamentos dos últimos 6 meses
                DateTime dataMin = DateTime.Now.AddMonths(-6);


                //Usa-se o ToList() primeiro para trazer tudo para memória — a construção de DateTime
                //e o acesso ao dicionário (meses[...]) não são traduzíveis para SQL.

                var orcamentos = db.DBOrcamentos
                                   .ToList()     
                                   .Where(o => new DateTime(o.Ano, meses[o.Mes], 1) >= dataMin
                                            && new DateTime(o.Ano, meses[o.Mes], 1) < DateTime.Today) //define o intervalo dos últimos 6 meses
                                   .ToList();


                //Verificamos se existe elementos na lista para calcular a média e a sugestão
                if (orcamentos.Any())
                {
                   sugestao.MediaUltimosMeses = orcamentos.Average(o => o.Valor);
                   sugestao.SugestaoProximoMes = sugestao.MediaUltimosMeses;

                   mensagem = "Sugestões de orçamentos geradas com sucesso!";
                }

                //Senão existir o utilizador é notificado que não foi possível calcular
                else
                {
                    mensagem = "Não foi possível calcular as estatísticas de orçamento! Verifique se tem orçamentos!";
                    return null;
                }

                return sugestao; //devolve a instância
            }
        }

        //Mostra na Grelha o histórico de orçamento vs o total gasto em cada mês
        public static void MostrarHistoricoOrcamento()
        {
            //Dicionário nome do mês para número do mês
            var meses = ControllerOrcamento.DevolverIntMesCorrespondente();

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //AsEnumerable() porque o dicionário não é reconhecível pela BD

                var orcamentos = db.DBOrcamentos
                                .AsEnumerable()    
                                .Select(o =>
                                {
                                    int mesNumero = meses[o.Mes];

                                    decimal totalCompras = db.DBCompras
                                        .Where(c =>
                                            c.DataFecho.Value.Year == o.Ano &&     //obtém o ano da dataFecho
                                            c.DataFecho.Value.Month == mesNumero) // obtém o mês da dataFecho

                                        //Soma o total gasto nas compras fechadas do mês e ano do fecho, correspondente ao orçamento com os mesmos valores
                                        .Sum(c => (decimal?)c.TotalGasto) ?? 0; 


                                    //Criamos a vista para a data grid view com os campos pretendidos
                                    return new
                                    {
                                        o.Ano,
                                        o.Mes,
                                        Orcamento = o.Valor,                 //Valor do orçamento
                                        TotalCompras = totalCompras,        //Total das compras que afetaram o orçamento
                                        Diferenca = o.Valor - totalCompras //Diferença do orçamento com as compras
                                    };
                                })
                                .ToList();

                //Validação para verificar que a lista não está vazia
                if (orcamentos.Any())
                {
                    EstatisticasForm.historicoOrcamentos.DataSource = orcamentos;
                }

                //Se estiver:
                else
                {
                    MessageBox.Show("Sem orçamentos para apresentar");
                    return;
                }
            }
        }


        //Mostra, por cada compra fechada, a percentagem de itens previstos vs não previstos
        public static void MostrarEstatisticasArtigos()
        {
            //Ligação à base de dados
            using(IShoppingContext db = new IShoppingContext())
            {   
                //Obtém todas as compras fechadas
                var comprasFechadas = db.DBCompras
                        .Where(c => c.Fechado)
                        .ToList()
                        .Select(compra =>
                        {
                            //Conta os itens previstos desta compra
                            int previstos = db.DBItensCompra.OfType<ItemPrevisto>()
                                .Count(i => i.CompraId == compra.Id);

                            //Conta os itens não previstos desta compra
                            int naoPrevistos = db.DBItensCompra.OfType<ItemNaoPrevisto>()
                                .Count(i => i.CompraId == compra.Id);

                            int total = previstos + naoPrevistos;

                            //Cria a vista para mostrar na DataGridView com o nome da compra
                            //a data de fecho e a percentagem
                            //de itens previstos e não previstos
                            return new
                            {
                                Compra = compra.NomeCompra,
                                DataFecho = compra.DataFecho,
                                PercentagemPrevistos = total == 0 ? 0 : (decimal)previstos * 100 / total,       // caso o total seja nulo assume o valor de 0
                                PercentagemNaoPrevistos = total == 0 ? 0 : (decimal)naoPrevistos * 100 / total // caso o total seja nulo assume o valor de 0
                            };
                        })
                        .ToList();

                //Mostra na DataGridView
                EstatisticasForm.ListagemPercentagem.DataSource = comprasFechadas;
            }
        }

    }
}
