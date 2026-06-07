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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iShopping_Abakos.View
{
    public partial class AdicionarItensNaoPrevistosForm : Form
    {
        public static Label labelNome;          // Referências estáticas a duas labels do formulário, para poderem ser
        public static Label labelValorTotal;    // acedidas a partir de fora da instância

        public AdicionarItensNaoPrevistosForm()
        {
            InitializeComponent();
            labelNome = label_NomeCompra;       // Guarda nos campos estáticos as labels desta instância (nome da compra e total)
            labelValorTotal = label_TotalCompra;
        }

                    

        private void AdicionarItensNaoPrevistosForm_Load(object sender, EventArgs e)
        {
            // Pede ao controller para preencher a combobox com os tipos de artigo
            ControllerAdicionarItensNaoPrevistos.CarregarTiposArtigo(comboBox_TipoArtigo);
            comboBox_TipoArtigo.SelectedIndex = -1;

            // Pede ao controller para mostrar a lista de itens da compra na grelha
            ControllerAdicionarItensNaoPrevistos.MostrarListaItens(dataGridView_ItensCompra);
        }

        

        private void buttonAdicionarItemNP_Click_1(object sender, EventArgs e)
        {
            // Se não houver nenhum artigo selecionado, avisa e interrompe
            if (comboBoxArtigo.SelectedValue == null)
            {
                MessageBox.Show("Selecione um artigo!");
                return;
            }

            // Chama o controller para adicionar o item não previsto, passando: id do artigo, quantidade, observações; recebe a mensagem de resultado
            ControllerAdicionarItensNaoPrevistos.AdicionarItemNaoPrevisto((int)comboBoxArtigo.SelectedValue, (int)numericUpDownQuantidade.Value, textBox_Observacoes.Text.Trim(), out string mensagem);
            MessageBox.Show(mensagem);

            // Atualiza a grelha para refletir o item recém-adicionado
            ControllerAdicionarItensNaoPrevistos.MostrarListaItens(dataGridView_ItensCompra);

            ControllerAdicionarItensNaoPrevistos.LimparCampos(comboBox_TipoArtigo, comboBoxArtigo, numericUpDownQuantidade, textBox_Observacoes, textBox_ID_NP);
        }



        private void buttonApagarItemNP_Click_1(object sender, EventArgs e)
        {
            // Pede ao controller para eliminar o item cujo ID está no textbox e recebe a mensagem
            ControllerAdicionarItensNaoPrevistos.EliminarItem(textBox_ID_NP.Text.Trim(), out string mensagem);
            MessageBox.Show(mensagem);
            ControllerAdicionarItensNaoPrevistos.MostrarListaItens(dataGridView_ItensCompra);  // Atualiza a grelha após a eliminação

            ControllerAdicionarItensNaoPrevistos.LimparCampos(comboBox_TipoArtigo, comboBoxArtigo, numericUpDownQuantidade, textBox_Observacoes, textBox_ID_NP);
        }



        private void buttonAlterarQuantNP_Click_1(object sender, EventArgs e)
        {
            // Pede ao controller para alterar a quantidade do item indicado pelo ID e recebe a mensagem
            ControllerAdicionarItensNaoPrevistos.AlterarQuantidade(textBox_ID_NP.Text.Trim(), (int)numericUpDownQuantidade.Value, out string mensagem);
            MessageBox.Show(mensagem);
            ControllerAdicionarItensNaoPrevistos.MostrarListaItens(dataGridView_ItensCompra);  // Atualiza a grelha após a alteração
            ControllerAdicionarItensNaoPrevistos.LimparCampos(comboBox_TipoArtigo, comboBoxArtigo, numericUpDownQuantidade, textBox_Observacoes, textBox_ID_NP);
        }



        private void button_Voltar_Click_1(object sender, EventArgs e)
        {
            VisualizarCompraForm.instance.Show();  // Reabre o formulário anterior(Visualizar Compra) através da instância
            this.Close();   // Fecha este form

        }



        private void comboBox_TipoArtigo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox_TipoArtigo.SelectedValue == null)  // Se não houver valor selecionado, não faz nada
            {
                return;
            }

            if (!(comboBox_TipoArtigo.SelectedValue is int tipoArtidoId))  // Se o valor selecionado não for um inteiro, não faz nada
            {
                return;
            }

            if (tipoArtidoId == 0)  // Se o tipo selecionado for 0 (opção sem tipo válido), avisa e interrompe
            {
                MessageBox.Show("Selecione um tipo de artigo");
                return;
            }

            // Pede ao controller para carregar na combobox os artigos do tipo escolhido (filtragem)
            ControllerAdicionarItensNaoPrevistos.CarregarArtigos(comboBoxArtigo, tipoArtidoId);
        }
    }
}
