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
    internal class ControllerVisualizarCompra
    {

        public static Compra compraDevolvida;
        public static void VoltarPaginaPrincipal()
        {
            VisualizarCompraForm.instance.Close();
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
        }

        public static void AbrirCompra(Compra compra)
        {
            if(compra == null)
            {
                return;
            }

            compraDevolvida = compra;
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            VisualizarCompraForm form = new VisualizarCompraForm();
            VisualizarCompraForm.labelNomeCompra.Text = "Nome da compra: " + compra.NomeCompra;
            form.ShowDialog();

        }

        public static void MostrarItensCompra(DataGridView datasource)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                //lista itens previstos
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
                        Descricao = ""                                          // como fazemos concat, ambas listas tem que ter as mesmas propriedades
                    }).ToList();

                //lista itens não previstos
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
                        o.Descricao
                    }).ToList();

                //concatena as duas listas
                var todos = previstos.Concat(naoPrevistos).ToList();

                datasource.DataSource = todos;
            }
        }



        public static void FecharCompra(out string mensagem)
        {
            string mesAtual = DateTime.Today.ToString("MMMM");
            int anoAtual = DateTime.Today.Year;

            if (compraDevolvida.Fechado == true)
            {
                mensagem = "A Compra já se encontra fechada";
                return;
            }
            else
            {
                using (IShoppingContext db = new IShoppingContext())
                {

                   var CompraFechar = db.DBCompras.FirstOrDefault(o => o.Id == compraDevolvida.Id );
                    
                    if(CompraFechar != null)
                    {
                        CompraFechar.Fechado = true;
                        CompraFechar.TotalGasto = ControllerCompras.ObterTotalGastoCompra(compraDevolvida.Id);
                        CompraFechar.FechadoPor = Sessao.UtilizadorAtual;
                        CompraFechar.DataFecho = DateTime.Now;
                    }


                    var orcamentoAtual = db.DBOrcamentos.FirstOrDefault(o => o.Ano == anoAtual && o.Mes == mesAtual);

                    decimal orcamentoAfetado = orcamentoAtual.Valor - CompraFechar.TotalGasto;


                    PaginaInicialForm.label.Text = orcamentoAfetado.ToString();

                    db.SaveChanges();
                }

                mensagem = "Compra fechada"; 
            } 
        }
    }
}
