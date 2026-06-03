using iShopping_Abakos.Controller;
using iShopping_Abakos.Model;
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
    public partial class PaginaInicialForm : Form
    {
        public static DataGridView comprasPaginaPrincipal;
        public static PaginaInicialForm instanciaPaginaPrincipal; // para poder manipular livremente
        public static Label label;
        public PaginaInicialForm()
        {
            InitializeComponent();
            instanciaPaginaPrincipal = this;
            label = label_Orcamento;
            comprasPaginaPrincipal = dataGridViewCompras;
           
        }

        private void PaginaInicialForm_Load(object sender, EventArgs e)
        {
            
            label_NomeUsername.Text = "Bem vindo, " + Sessao.UtilizadorAtual + "!";
            Orcamento orcamento = ControllerPaginaInicial.DevolverOrcamentoAtual();

            comboBoxEstado.SelectedIndex = 0;

            if (orcamento != null)
            {

                label.Text = orcamento.Valor.ToString() + "€";
            }
            else
            {

                label.Text = " — ";
            }
        }

        private void button_Orcamento_Click(object sender, EventArgs e)
        {
            

            ControllerPaginaInicial.AbrirFormOrcamentos();
            //passo como parâmetro para poder esconder a página principal quando o form orçamento abre

            
        }

        private void button_TipoArtigos_Click(object sender, EventArgs e)
        {
            ControllerPaginaInicial.AbrirFormTipoArtigo();

        }

        private void button_Artigos_Click(object sender, EventArgs e)
        {
            ControllerPaginaInicial.AbrirFormArtigos();
        }

        private void button_Compras_Click(object sender, EventArgs e)
        {
            ControllerPaginaInicial.AbrirFormCompras();
            comboBoxEstado.SelectedIndex = 0;
        }

        private void button_Estatisticas_Click(object sender, EventArgs e)
        {
            ControllerPaginaInicial.AbrirFormEstatisticas();
        }

        private void button_VisualizarDetalhes_Click(object sender, EventArgs e)
        {
            ControllerPaginaInicial.AbrirFormVisualizar();
        }

        private void button_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label_Orcamento_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ControllerPaginaInicial.MostrarEstadoCompras(comboBoxEstado.SelectedIndex, dataGridViewCompras);

        }
    }
}
