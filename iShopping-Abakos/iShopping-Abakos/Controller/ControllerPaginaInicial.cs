using iShopping_Abakos;
using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerPaginaInicial
    {

        public static void AbrirFormOrcamentos()
        {

            //escondemos o principal, damos conceal ao user
            // se fosse close, a aplicação termina automaticamente
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            OrcamentosForm Form = new OrcamentosForm();
            Form.ShowDialog();
            
        }

   
        public static void AbrirFormArtigos()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            ArtigosForm Form = new ArtigosForm();
            Form.ShowDialog();
        }

        public static void AbrirFormCompras()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            ComprasForm Form = new ComprasForm();
            Form.ShowDialog();
        }

        public static void AbrirFormEstatisticas()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            EstatisticasForm Form = new EstatisticasForm();
            Form.ShowDialog();
        }
        public static void AbrirFormTipoArtigo()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            TipoArtigoForm Form = new TipoArtigoForm();
            Form.ShowDialog();
        }

        /*public static void AbrirFormVisualizar()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            VisualizarCompraForm Form = new VisualizarCompraForm();
            Form.ShowDialog();
        }*/

        public static Orcamento DevolverOrcamentoAtual()
        {
            string mesAtual = DateTime.Today.ToString("MMMM");
            int anoAtual = DateTime.Today.Year;
            

            using (IShoppingContext db = new IShoppingContext())
            {
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(
                    o => o.Mes == mesAtual && o.Ano == anoAtual);


                return orcamento;
            }

        }

        public static void MostrarEstadoCompras(int estado, DataGridView dataSource)
        {
            if (estado == 0)
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    dataSource.DataSource = db.DBCompras.OrderBy(c => c.Id).ToList();

                }

                
            }
            else if (estado == 1)
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    dataSource.DataSource = db.DBCompras.Where(c => c.Fechado == false).OrderBy(c => c.Id).ToList();
                }
            }
            else if (estado == 2)
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    dataSource.DataSource = db.DBCompras.Where(c => c.Fechado == true).OrderBy(c => c.Id).ToList();
                }
            }
        }

        public static Compra DevolverCompra(string id)
        {
            int idCompra;


            if (id == "")
            {
                MessageBox.Show("Por favor insira um Id");
                return null;
            }

            if (!int.TryParse(id, out idCompra))
            {
                MessageBox.Show("O Id tem de ser numérico");
                return null;
            }


            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra);

                if (compra != null)
                {
                    return compra;
                }
                else
                {
                    MessageBox.Show("Selecione uma compra existente!");
                    return null;
                }
            }
        }
    }
}
