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
    public partial class AdicionarItensPrevistosForm : Form
    {
        public AdicionarItensPrevistosForm()
        {
            InitializeComponent();
        }

        private void button_Voltar_Click(object sender, EventArgs e)
        {
            ComprasForm.instance.Show();
            this.Close();
        }
    }
}
