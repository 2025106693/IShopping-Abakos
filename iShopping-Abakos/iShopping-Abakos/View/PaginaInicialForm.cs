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
        public static PaginaInicialForm instanciaPaginaPrincipal; // para poder manipular livremente
        public PaginaInicialForm()
        {
            InitializeComponent();
            instanciaPaginaPrincipal = this;

            Orcamento orcamento = ControllerPaginaInicial.MostrarOrcamento(); 
            
            label_Orcamento.Text = orcamento.Valor.ToString();
            label_NomeUsername.Text = "Bem vindo, " + Sessao.UtilizadorAtual + "!";
        }

        private void PaginaInicialForm_Load(object sender, EventArgs e)
        {
            Orcamento orcamento = ControllerPaginaInicial.DevolverOrcamentoAtual();

            if (orcamento != null)
            {

                label_Orcamento.Text = orcamento.Valor.ToString() + "€";
            }
            else
            {

                label_Orcamento.Text = " — ";
            }
        }

        private void button_Orcamento_Click(object sender, EventArgs e)
        {
            

            ControllerPaginaInicial.AbrirFormOrcamentos(instanciaPaginaPrincipal);
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


    }
}
