using iShopping_Abakos.Controller;
using System;
using System.Windows.Forms;

namespace iShopping_Abakos.View
{
    public partial class AdicionarItensPrevistosForm : Form
    {
        // Label utilizada para apresentar o nome da compra selecionada
        public static Label labelNome;

        // Label utilizada para apresentar o valor total previsto da compra
        public static Label labelPrevisto;
        public AdicionarItensPrevistosForm()
        {
            InitializeComponent();

            //Associa os labels do formulário às variáveis estáticas
            labelNome = label_NomeCompra;
            labelPrevisto = label_TotalPrevisto;
        }

        private void button_Voltar_Click(object sender, EventArgs e)
        {
            //Atualiza a listagem de compras
            ControllerCompras.MostrarCompras(ComprasForm.dataGridView);

            //Volta a apresentar o formulário de compras
            ComprasForm.instance.Show();

            //Fecha o formulário atual
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


            ControllerAdicionarItensPrevistos.AdicionarItemPrevisto(artigoId, qtdPrevista, out mensagem);
            MessageBox.Show(mensagem);

            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);

        }

        private void AdicionarItensPrevistosForm_Load(object sender, EventArgs e)
        {
            ControllerAdicionarItensPrevistos.CarregarTiposArtigo(comboBox_TiposArtigos);
            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);
            comboBox_TiposArtigos.SelectedIndex = -1;

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
            ControllerAdicionarItensPrevistos.EliminarItem(textBox_ID.Text.Trim(), out string mensagem);
            MessageBox.Show(mensagem);
            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);
        }



        private void button_AlterarQuantidade_Click(object sender, EventArgs e)
        {
            ControllerAdicionarItensPrevistos.AlterarQuantidade(textBox_ID.Text.Trim(), (int)numericUpDown1.Value, out string mensagem);
            MessageBox.Show(mensagem);
            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);
        }
    }
}
