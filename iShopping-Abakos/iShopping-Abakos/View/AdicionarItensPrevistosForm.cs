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

        private void button_AdicionarItem_Click(object sender, EventArgs e)
        {

        }

        private void AdicionarItensPrevistosForm_Load(object sender, EventArgs e)
        {
            ControllerAdicionarItensPrevistos.CarregarTiposArtigo(comboBox_TiposArtigos);
            
        }

        private void comboBox_TiposArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_TiposArtigos.SelectedValue == null) return;
            if (!(comboBox_TiposArtigos.SelectedValue is int tipoArtigoId)) return;

            if (tipoArtigoId == 0)
            {
                MessageBox.Show("Selecione um tipo de artigo");
                return;
            }

            ControllerAdicionarItensPrevistos.CarregarArtigos(comboBox2_Artigos, tipoArtigoId);

        }
    }
}
