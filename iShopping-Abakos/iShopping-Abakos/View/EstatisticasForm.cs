using iShopping_Abakos.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.View
{
    public partial class EstatisticasForm : Form
    {
        public static EstatisticasForm instance;
        public EstatisticasForm()
        {
            InitializeComponent();
            instance = this;
        }

        private void button_Voltar_Click(object sender, EventArgs e)
        {
            ControllerEstatisticas.VoltarPaginaPrincipal();
        }
    }
}
