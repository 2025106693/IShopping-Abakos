using iShopping_Abakos.Controller;
using iShopping_Abakos.Model;
using System;
using System.Windows.Forms;

namespace iShopping_Abakos
{
    public partial class PaginaInicialForm : Form
    {
        // DataGridView utilizada para apresentar as compras na página principal
        public static DataGridView comprasPaginaPrincipal;

        // Instância do formulário para permitir o seu acesso a partir de outras classes
        public static PaginaInicialForm instanciaPaginaPrincipal;

        // Label responsável por apresentar o orçamento atual
        public static Label label;
        public PaginaInicialForm()
        {
            InitializeComponent();
            
            //Guarda referências aos componentes principais do formulário

            instanciaPaginaPrincipal = this;
            label = label_Orcamento;
            comprasPaginaPrincipal = dataGridViewCompras;
           
        }

        private void PaginaInicialForm_Load(object sender, EventArgs e)
        {
            //Apresenta uma mensagem de boas-vindas ao utilizador autenticado
            label_NomeUsername.Text = "Bem vindo, " + Sessao.UtilizadorAtual + "!";

            //Obtém o orçamento atualmente definido
            Orcamento orcamento = ControllerOrcamento.DevolverOrcamentoAtual();

            //Seleciona o primeiro estado da ComboBox por defeito
            comboBoxEstado.SelectedIndex = 0;

            //Atualiza a label com o valor do orçamento caso exista
            if (orcamento != null)
            {

                label.Text = orcamento.Valor.ToString() + "€";
            }
            else
            {
                //Caso não exista orçamento definido
                label.Text = " — ";
            }
        }

        private void button_Orcamento_Click(object sender, EventArgs e)
        {
            //Abre o formulário de gestão de orçamentos
            ControllerPaginaInicial.AbrirFormOrcamentos();
            
        }

        private void button_TipoArtigos_Click(object sender, EventArgs e)
        {
            //Abre o formulário de gestão de tipos de artigo
            ControllerPaginaInicial.AbrirFormTipoArtigo();

        }

        private void button_Artigos_Click(object sender, EventArgs e)
        {
            //Abre o formulário de gestão de artigos
            ControllerPaginaInicial.AbrirFormArtigos();
        }

        private void button_Compras_Click(object sender, EventArgs e)
        {
            //Abre o formulário de gestão de compras
            ControllerPaginaInicial.AbrirFormCompras();

            //Repõe o filtro de estado para a opção padrão
            comboBoxEstado.SelectedIndex = 0;
        }

        private void button_Estatisticas_Click(object sender, EventArgs e)
        {
            //Abre o formulário de estatísticas
            ControllerPaginaInicial.AbrirFormEstatisticas();
        }

        private void button_VisualizarDetalhes_Click(object sender, EventArgs e)
        {
            //Obtém a compra correspondente ao ID introduzido
            Compra compra = ControllerPaginaInicial.DevolverCompra(textBox_Id.Text.Trim());

            //Abre o formulário de vizualização da compra selecionada
            ControllerVisualizarCompra.AbrirCompra(compra);
        }

        private void button_Sair_Click(object sender, EventArgs e)
        {
            //Fecha a aplicação
            this.Close();
        }

        private void label_Orcamento_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Atualiza a lista de compras de acordo com o estado selecionado
            ControllerPaginaInicial.MostrarEstadoCompras(comboBoxEstado.SelectedIndex, dataGridViewCompras);

        }

        private void button_ExportarCSV_Click(object sender, EventArgs e)
        {
            //Exporta a lista de compras fechadas
            ControllerPaginaInicial.BotaoExportarCSV();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
