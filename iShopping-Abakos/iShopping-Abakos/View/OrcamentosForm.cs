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
    public partial class OrcamentosForm : Form
    {
        //instância do formulário para permitir o acesso a partir do controller
        public static OrcamentosForm formOrcamento;

        public OrcamentosForm()
        {
            InitializeComponent();
            formOrcamento = this;  //guarda a referência     
        }

        //Evento do botão sair
        private void buttonSairOrcamentos_Click(object sender, EventArgs e)
        {
            //Fecha o formulário e regressa à página principal
            ControllerOrcamento.VoltarPaginaPrincipal();

        }

        //Evento do botão adicionar Orçamento
        private void buttonAdicionarOrcamento_Click(object sender, EventArgs e)
        {
            //Obtém os dados introduzidos pelo utilizador e retira espaços em branco no final
            string valor = textBoxValorOrcamento.Text.Trim();
            object mes = comboBoxMesesOrcamento.SelectedItem;
            string ano = textBoxAnoOrcamento.Text.Trim();

            //Cria um orçamento
            ControllerOrcamento.AdicionarOrcamento(valor, mes, ano);

            //Atualiza a tabela de orçamentos
            ControllerOrcamento.MostrarTabelaOrçamentos(dataGridView1);

            //Atualiza os labels informativos
            ControllerOrcamento.AtualizarLabels(labelMes, labelValorOrcamento);

            //Limpa os campos do formulário
            ControllerOrcamento.LimparCampos(textBoxValorOrcamento, comboBoxMesesOrcamento, textBoxAnoOrcamento, dataGridView1);


        }

        //Evento executado quando o formulário é carregado
        private void OrcamentosForm_Load(object sender, EventArgs e)
        {
            //Configurações da DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.RowHeadersWidth = 60;

            //Carrega os orçamentos existentes
            ControllerOrcamento.MostrarTabelaOrçamentos(dataGridView1);

            //Remove a seleção inicial da tabela
            dataGridView1.ClearSelection();

            //Atualiza os labels com os dados do orçamento atual
            ControllerOrcamento.AtualizarLabels(labelMes, labelValorOrcamento);
        }

        //Evento do botão Editar orçamento 
        private void buttonEditarOrcamento_Click(object sender, EventArgs e)
        {
            
            //Atualiza o orçamento selecionado
            ControllerOrcamento.AlterarOrcamentoAtual(textBoxID.Text.Trim(), textBoxValorOrcamento.Text.Trim(), dataGridView1);

            //Atualiza os labels informativos
            ControllerOrcamento.AtualizarLabels(labelMes, labelValorOrcamento);

            //Limpa os campos inseridos 
            ControllerOrcamento.LimparCampos(textBoxValorOrcamento, comboBoxMesesOrcamento, textBoxAnoOrcamento, dataGridView1);

        }

        private void button_eliminarOrcamento_Click(object sender, EventArgs e)
        {
            ControllerOrcamento.EliminarOrcamento(textBoxID.Text.Trim(), dataGridView1, out string mensagem);

            MessageBox.Show(mensagem);

            //Atualiza os labels informativos
            ControllerOrcamento.AtualizarLabels(labelMes, labelValorOrcamento);
        }
    }
}
