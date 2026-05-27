using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Controller
{
    internal class ControllerAdicionarItensPrevistos
    {
        public static void AbrirAdicionarItensPrevistosForm()
        {
            ComprasForm.instance.Hide();
            AdicionarItensPrevistosForm form = new AdicionarItensPrevistosForm();
            form.ShowDialog();
            
        }
    }
}
