using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
