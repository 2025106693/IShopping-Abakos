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
    public partial class AdicionarItensNaoPrevistosForm : Form
    {
        public static Label labelNome;
        public static Label labelValorTotal;

        public AdicionarItensNaoPrevistosForm()
        {
            InitializeComponent();
            labelNome = label_NomeCompra;
            labelValorTotal = label_TotalCompra;
        }



        private void AdicionarItensNaoPrevistosForm_Load(object sender, EventArgs e)
        {
            ControllerAdicionarItensNaoPrevistos.CarregarTiposArtigo(comboBox_TipoArtigo);
            ControllerAdicionarItensNaoPrevistos.MostrarListaItens(dataGridView_ItensCompra);
        }

        

        private void buttonAdicionarItemNP_Click_1(object sender, EventArgs e)
        {
            if (comboBoxArtigo.SelectedValue == null)
            {
                MessageBox.Show("Selecione um artigo!");
                return;
            }

            ControllerAdicionarItensNaoPrevistos.AdicionarItemNaoPrevisto((int)comboBoxArtigo.SelectedValue, (int)numericUpDownQuantidade.Value, textBox_Observacoes.Text.Trim(), out string mensagem);
            MessageBox.Show(mensagem);
            ControllerAdicionarItensNaoPrevistos.MostrarListaItens(dataGridView_ItensCompra);
        }



        private void buttonApagarItemNP_Click_1(object sender, EventArgs e)
        {
            ControllerAdicionarItensNaoPrevistos.EliminarItem(textBox_ID_NP.Text.Trim(), out string mensagem);
            MessageBox.Show(mensagem);
            ControllerAdicionarItensNaoPrevistos.MostrarListaItens(dataGridView_ItensCompra);
        }



        private void buttonAlterarQuantNP_Click_1(object sender, EventArgs e)
        {
            ControllerAdicionarItensNaoPrevistos.AlterarQuantidade(textBox_ID_NP.Text.Trim(), (int)numericUpDownQuantidade.Value, out string mensagem);
            MessageBox.Show(mensagem);
            ControllerAdicionarItensNaoPrevistos.MostrarListaItens(dataGridView_ItensCompra);
        }



        private void button_Voltar_Click_1(object sender, EventArgs e)
        {
            VisualizarCompraForm.instance.Show();
            this.Close();
        }



        private void comboBox_TipoArtigo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox_TipoArtigo.SelectedValue == null)
            {
                return;
            }

            if (!(comboBox_TipoArtigo.SelectedValue is int tipoArtidoId))
            {
                return;
            }

            if (tipoArtidoId == 0)
            {
                MessageBox.Show("Selecione um tipo de artigo");
                return;
            }


            ControllerAdicionarItensNaoPrevistos.CarregarArtigos(comboBoxArtigo, tipoArtidoId);
        }
    }
}
