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
    public partial class VisualizarCompraForm : Form
    {
        public static VisualizarCompraForm instance;
        public static Label labelNomeCompra;
        public VisualizarCompraForm()
        {
            InitializeComponent();
            labelNomeCompra = label_Descricao_FormCompras;
            instance = this;
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            ControllerVisualizarCompra.VoltarPaginaPrincipal();
        }

        private void VisualizarCompraForm_Load(object sender, EventArgs e)
        {

        }
    }
}
