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
    }
}
