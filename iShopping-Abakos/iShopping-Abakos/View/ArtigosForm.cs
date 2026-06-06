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

            dataGridViewArtigos.AutoGenerateColumns = true;
            dataGridViewArtigos.RowHeadersWidth = 60;
            ControllerArtigo.MostrarTabelaArtigos(dataGridViewArtigos);
            dataGridViewArtigos.ClearSelection();
            // Para mostar os tipos de artigos guardadosna tabela TipoArtigos
            ControllerArtigo.CarregarTiposArtigo(comboBoxTipoArtigo);
        }

        private void button_AdicionarArtigo_Click_1(object sender, EventArgs e)
        {
            ControllerArtigo.botaoAdicionar(textBoxNomeArtigo.Text.Trim(), textBox_Preco.Text, textBoxDescricaoArtigo.Text, comboBoxTipoArtigo, out string mensagem);
            ControllerArtigo.MostrarTabelaArtigos(dataGridViewArtigos);
            MessageBox.Show(mensagem);
            ControllerArtigo.LimparCampos(textBoxNomeArtigo, textBox_Preco, comboBoxTipoArtigo, textBoxDescricaoArtigo, textBoxIDArtigo, dataGridViewArtigos);
        }

        private void buttonAlterarArtigo_Click(object sender, EventArgs e)
        {
            
            ControllerArtigo.AlterarArtigo(dataGridViewArtigos, textBoxIDArtigo.Text.Trim(), textBoxNomeArtigo.Text.Trim(), textBox_Preco.Text.Trim(), comboBoxTipoArtigo, textBoxDescricaoArtigo.Text.Trim(), out string mensagem);
            MessageBox.Show(mensagem);
            ControllerArtigo.LimparCampos(textBoxNomeArtigo, textBox_Preco, comboBoxTipoArtigo, textBoxDescricaoArtigo, textBoxIDArtigo, dataGridViewArtigos);
        }

        private void buttonEliminarArtigo_Click(object sender, EventArgs e)
        {
            ControllerArtigo.EliminarArtigos(textBoxIDArtigo.Text.Trim(), dataGridViewArtigos, out string mensagem);
            MessageBox.Show(mensagem);
            ControllerArtigo.LimparCampos(textBoxNomeArtigo, textBox_Preco, comboBoxTipoArtigo, textBoxDescricaoArtigo, textBoxIDArtigo, dataGridViewArtigos);
        }
    }
}