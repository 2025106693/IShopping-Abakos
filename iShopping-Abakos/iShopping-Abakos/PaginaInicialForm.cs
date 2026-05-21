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

namespace iShopping_Abakos
{
    public partial class PaginaInicialForm : Form
    {
        public PaginaInicialForm()
        {
            InitializeComponent();
        }

        private void PaginaInicialForm_Load(object sender, EventArgs e)
        {

        }

        private void button_Orcamento_Click(object sender, EventArgs e)
        {
            ControllerPaginaInicial.AbrirFormOrcamentos();
        }
    }
}
