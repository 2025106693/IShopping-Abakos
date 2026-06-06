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
        public static OrcamentosForm formOrcamento;
        public static Label labelMesAtual;
        public static Label labelValorOrcamentoAtual;
        
        public OrcamentosForm()
        {
            InitializeComponent();
            formOrcamento = this; 
            labelMesAtual = labelMes;   // label do form design
            labelValorOrcamentoAtual = labelValorOrcamento;
        }

        private void buttonSairOrcamentos_Click(object sender, EventArgs e)
        {
            ControllerOrcamento.VoltarPaginaPrincipal(); //chamamos a funcao 
        }

        private void buttonAdicionarOrcamento_Click(object sender, EventArgs e)
        {
            string mensagem = "";

            ControllerOrcamento.AdicionarOrcamento(textBoxValorOrcamento.Text.Trim(), comboBoxMesesOrcamento, textBoxAnoOrcamento.Text.Trim(), out mensagem);

            MessageBox.Show(mensagem);

            ControllerOrcamento.MostrarTabelaOrçamentos(dataGridView1);

            ControllerOrcamento.DevolverOrcamentoAtual();


        }

        private void OrcamentosForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.RowHeadersWidth = 60;
            ControllerOrcamento.MostrarTabelaOrçamentos(dataGridView1);
            dataGridView1.ClearSelection();

            ControllerOrcamento.DevolverOrcamentoAtual();

        }

        private void buttonEditarOrcamento_Click(object sender, EventArgs e)
        {
            ControllerOrcamento.AlterarOrcamentoAtual(textBoxID.Text.Trim(), textBoxValorOrcamento.Text.Trim(), dataGridView1);

            ControllerOrcamento.DevolverOrcamentoAtual();

        }        
    }
}
