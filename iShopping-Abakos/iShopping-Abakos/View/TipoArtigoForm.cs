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
    public partial class TipoArtigoForm : Form
    {
        public static TipoArtigoForm tipoArtigoForm;
        public TipoArtigoForm()
        {
            InitializeComponent();
            tipoArtigoForm = this;
            
        }

        private void button_Voltar_Click(object sender, EventArgs e)
        {
            ControllerTiposArtigo.VoltarPaginaPrincipal();
        }

        private void buttonAdicionarTipoArtigo_Click(object sender, EventArgs e)
        {
            string nome = textBoxNomeTipoArtigo.Text.ToString();
            string descricao = textBoxDescricaoTipoArtigo.Text.ToString();

            ControllerTiposArtigo.AdicionarTipoArtigo(nome, descricao);
            ControllerTiposArtigo.MostrarTabelaTipoArtigo(dataGridViewTipoArtigos);
        }

        private void buttonAlterarTipoArtigo_Click(object sender, EventArgs e)
        {
            ControllerTiposArtigo.AlterarTipoArtigo(textBoxIDtipoArtigo.Text.Trim(), textBoxNomeTipoArtigo.Text,
                                                        textBoxDescricaoTipoArtigo.Text, dataGridViewTipoArtigos);
        }

        private void TipoArtigoForm_Load(object sender, EventArgs e)
        {
            dataGridViewTipoArtigos.AutoGenerateColumns = true;
            dataGridViewTipoArtigos.RowHeadersWidth = 60;
            ControllerTiposArtigo.MostrarTabelaTipoArtigo(dataGridViewTipoArtigos);
            dataGridViewTipoArtigos.ClearSelection();
        }

        private void buttonEliminarTipoArtigo_Click(object sender, EventArgs e)
        {

        }
    }
}
