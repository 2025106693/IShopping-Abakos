using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Controller
{
    internal class ControllerEstatisticas
    {
        public static void VoltarPaginaPrincipal()
        {
            EstatisticasForm.instance.Close();
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
        }
    }
}
