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
        public OrcamentosForm()
        {
            InitializeComponent();

            Orcamento orcamento = ControllerOrcamento.DevolverOrcamentoAtual();

            if (orcamento != null)
            {
                labelMes.Text = "Mês: " + orcamento.Mes;
                labelValorOrcamento.Text = orcamento.Valor.ToString() + "€";
            }
            else
            {
                labelMes.Text = "Mês: — ";
                labelValorOrcamento.Text = " — ";
            }
        }

        private void buttonSairOrcamentos_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdicionarOrcamento_Click(object sender, EventArgs e)
        {
            

            string valor = textBoxValorOrcamento.Text.Trim();
            string mes = comboBoxMesesOrcamento.SelectedItem.ToString();
            string ano = textBoxAnoOrcamento.Text.Trim();

             ControllerOrcamento.AdicionarOrcamento(valor, mes, ano);
             ControllerOrcamento.MostrarTabelaOrçamentos(dataGridView1);



        }

        private void OrcamentosForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.RowHeadersWidth = 60;
            ControllerOrcamento.MostrarTabelaOrçamentos(dataGridView1);
            dataGridView1.ClearSelection();

        }
    }
}
