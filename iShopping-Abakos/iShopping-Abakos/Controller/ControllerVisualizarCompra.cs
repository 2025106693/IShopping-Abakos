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
        public static void VoltarPaginaPrincipal()
        {
            VisualizarCompraForm.instance.Close();
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
        }
    }
}
