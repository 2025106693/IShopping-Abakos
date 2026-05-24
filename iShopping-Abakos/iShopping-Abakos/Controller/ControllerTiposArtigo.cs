using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Controller
{
    internal class ControllerTiposArtigo
    {
        public static void VoltarPaginaPrincipal()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
            TipoArtigoForm.tipoArtigoForm.Close();
        }
    }
}
