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
        public static Label labelNome;
        public static Label labelPrevisto;
        public AdicionarItensPrevistosForm()
        {
            InitializeComponent();
            labelNome = label_NomeCompra;
            labelPrevisto = label_TotalPrevisto;
        }

        private void button_Voltar_Click(object sender, EventArgs e)
        {
            ControllerCompras.MostrarCompras(ComprasForm.dataGridView);
            ComprasForm.instance.Show();
            this.Close();
            
        }

        private void button_AdicionarItem_Click(object sender, EventArgs e)
        {
            if (comboBox2_Artigos.SelectedValue == null)
            {
                MessageBox.Show("Selecione um artigo!");
                return;
            }

            int artigoId = (int)comboBox2_Artigos.SelectedValue;
            int qtdPrevista = (int)numericUpDown1.Value;
            string mensagem;


            ControllerAdicionarItensPrevistos.AdicionarItemPrevisto(
                 artigoId, qtdPrevista, out mensagem);
            MessageBox.Show(mensagem);

            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);

        }

        private void AdicionarItensPrevistosForm_Load(object sender, EventArgs e)
        {
            ControllerAdicionarItensPrevistos.CarregarTiposArtigo(comboBox_TiposArtigos);
            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);


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

        private void button_ApagarItem_Click(object sender, EventArgs e)
        {
            string mensagem = "";

            ControllerAdicionarItensPrevistos.EliminarItem(
                textBox_ID.Text.Trim(),
                out mensagem);

            MessageBox.Show(mensagem);
            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);


        }

        private void button_AlterarQuantidade_Click(object sender, EventArgs e)
        {
            string mensagem = "";

            ControllerAdicionarItensPrevistos.AlterarQuantidade(
                textBox_ID.Text.Trim(),
                (int)numericUpDown1.Value,
                out mensagem);

            MessageBox.Show(mensagem);

            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);

        }
    }
}
