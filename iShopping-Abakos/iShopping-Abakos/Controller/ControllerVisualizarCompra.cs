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
    //Controller responsável pelo VisualizarCompraForm
    internal class ControllerVisualizarCompra
    {
        
        public static Compra compraDevolvida;

        //Função para voltar à página principal e fechar a janela atual
        public static void VoltarPaginaPrincipal()
        {
            VisualizarCompraForm.instance.Close();
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
        }

        //Função de carregar todos os dados da compra selecionada
        public static void AbrirCompra(Compra compra)
        {
            //Verifica se a compra foi devolvida com sucesso
            //(se a inserção do id + existência do objeto na BD for válida) 
            //Realizado por: ControllerPaginaInicial.DevolverCompra(textBox_Id.Text.Trim());

            if (compra == null)
            {
                return;
            }

            //guarda a compra selecionada para utilização posterior
            compraDevolvida = compra;

            //Esconde a página principal
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();

            //abre o formulário de vizualização da compra (Nome + Lista de Itens)
            VisualizarCompraForm form = new VisualizarCompraForm();
            
            //Atualiza o nome da compra apresentado no formulário
            VisualizarCompraForm.labelNomeCompra.Text = "Nome da compra: " + compra.NomeCompra;
            
            form.ShowDialog();

        }

        //Função para obter a lista de todos os itens de Compra na DataGridView
        public static void MostrarItensCompra(DataGridView datasource)
        {
            //ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Obtém todos os itens previstos da compra através da tabela ItensCompra 

                var previstos = db.DBItensCompra.OfType<ItemPrevisto>()
                    .Where(o => o.CompraId == compraDevolvida.Id)
                    .Select(o => new
                    {
                        Artigo = o.Artigo.Nome,
                        Tipo = "Previsto",
                        o.QuantPrevista,
                        o.Quantidade,
                        o.PrecoUnitario,
                        TotalPrevisto = o.PrecoUnitario * o.QuantPrevista,
                        Observacoes = ""                             // como fazemos concat, ambas listas têm de ter as mesmas propriedades/colunas
                    }).ToList();

                //Obtém todos os itens não previstos da compra através da tabela ItensCompra 
                var naoPrevistos = db.DBItensCompra.OfType<ItemNaoPrevisto>()
                    .Where(o => o.CompraId == compraDevolvida.Id)
                    .Select(o => new
                    {
                        Artigo = o.Artigo.Nome,
                        Tipo = "Não Previsto",
                        QuantPrevista = 0,
                        o.Quantidade,
                        o.PrecoUnitario,
                        TotalPrevisto = o.PrecoUnitario * o.Quantidade,
                        o.Observacoes
                    }).ToList();

                //concatena as duas listas 
                var todosItens = previstos.Concat(naoPrevistos).ToList();

                datasource.DataSource = todosItens; //apresenta os dados na grelha
            }
        }



        public static void FecharCompra(out string mensagem)
        {
            //obtém o mês e o ano atual
            string mesAtual = DateTime.Today.ToString("MMMM");
            int anoAtual = DateTime.Today.Year;

            //Verifica se a compra já foi fechada
            if (compraDevolvida.Fechado == true)
            {
                mensagem = "A Compra já se encontra fechada";
                return;
            }
            else
            {
                //ligação à base de dados
                using (IShoppingContext db = new IShoppingContext())
                {
                    //Obtém a compra na base de dados
                    var CompraFechar = db.DBCompras.FirstOrDefault(o => o.Id == compraDevolvida.Id );
                    
                    if(CompraFechar != null)
                    {
                        CompraFechar.Fechado = true;     

                        //Calcula o total gasto com uma função já existente
                        CompraFechar.TotalGasto = ControllerCompras.ObterTotalGastoCompra(compraDevolvida.Id);
                        
                        CompraFechar.FechadoPor = Sessao.UtilizadorAtual;  
                        CompraFechar.DataFecho = DateTime.Today;
                    }


                    //obtém o orçamento atual
                    var orcamentoAtual = db.DBOrcamentos.FirstOrDefault(o => o.Ano == anoAtual && o.Mes == mesAtual);

                    //calcula o valor restante do orçamento disponível
                    decimal orcamentoAfetado = orcamentoAtual.Valor - CompraFechar.TotalGasto;

                    //Atualiza o valor apresentado na página principal
                    PaginaInicialForm.label.Text = orcamentoAfetado.ToString();

                    //guarda as alterações na base de dados
                    db.SaveChanges();
                }

                //mensagem de sucesso
                mensagem = "Compra fechada"; 
            } 
        }
    }
}
