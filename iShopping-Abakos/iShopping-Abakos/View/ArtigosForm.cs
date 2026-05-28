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
    public partial class ArtigosForm : Form
    {
        public static ArtigosForm instance;
        public ArtigosForm()
        {
            InitializeComponent();
            instance = this;
        }

        private void button_Voltar_Click(object sender, EventArgs e)
        {
            ControllerArtigo.VoltarPaginaPrincipal();
        }

      

        private void ArtigosForm_Load(object sender, EventArgs e)
        {

            dataGridViewTipoArtigos.AutoGenerateColumns = true;
            dataGridViewTipoArtigos.RowHeadersWidth = 60;
            ControllerArtigo.MostrarTabelaArtigos(dataGridViewTipoArtigos);
            dataGridViewTipoArtigos.ClearSelection();

            // Para mostar os tipos de artigos guardadosna tabela TipoArtigos
            ControllerArtigo.CarregarTiposArtigo(comboBoxTipoArtigo);
        }

        private void button_AdicionarArtigo_Click_1(object sender, EventArgs e)
        {
            // Variavel que guarda id do objeto selecionado TipoArtigo  |
            // .SelectedValue devolve o ValueMember do "Id",
            int tipoArtigoId = (int)comboBoxTipoArtigo.SelectedValue;

            ControllerArtigo.botaoAdicionar(
                textBoxNomeArtigo.Text.Trim(),
                textBox_Preco.Text,
                textBoxDescricaoArtigo.Text,
                tipoArtigoId
                );

            ControllerArtigo.MostrarTabelaArtigos(dataGridViewTipoArtigos);

        }

        private void buttonAlterarArtigo_Click(object sender, EventArgs e)
        {
            int tipoArtigoId;

            if (comboBoxTipoArtigo.SelectedValue == null)
            {
                tipoArtigoId = -1;
            }
            else
            {
                tipoArtigoId = (int)comboBoxTipoArtigo.SelectedValue;
            }

            ControllerArtigo.AlterarArtigo(dataGridViewTipoArtigos, textBoxIDArtigo, textBoxNomeArtigo, textBox_Preco, tipoArtigoId, textBoxDescricaoArtigo);

        }

        private void buttonEliminarArtigo_Click(object sender, EventArgs e)
        {
            ControllerArtigo.EliminarArtigos(textBoxIDArtigo, dataGridViewTipoArtigos);

        }
    }
}