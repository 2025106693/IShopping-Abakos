using iShopping_Abakos;
using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerPaginaInicial
    {

        public static void AbrirFormOrcamentos()
        {
            OrcamentosForm Form = new OrcamentosForm();
            Form.ShowDialog();
        }
    }
}
