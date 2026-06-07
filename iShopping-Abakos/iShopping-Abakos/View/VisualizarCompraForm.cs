using iShopping_Abakos.Controller;
using System;
using System.Windows.Forms;

namespace iShopping_Abakos.View
{
    public partial class VisualizarCompraForm : Form
    {
        //Instância do formulário para acesso Global
        public static VisualizarCompraForm instance;

        //Instância da Label para acesso Global
        public static Label labelNomeCompra;

        public VisualizarCompraForm()
        {
            InitializeComponent();

            //Associa a label do formulário à variável estática
            labelNomeCompra = label_Descricao_FormCompras;

            //Guarda a instância atual do formulário
            instance = this;
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            //Regressa à página principal
            ControllerVisualizarCompra.VoltarPaginaPrincipal();

            //Atualiza o estado das compras apresentadas na página principal
            ControllerPaginaInicial.MostrarEstadoCompras(0, PaginaInicialForm.comprasPaginaPrincipal);
        }


        private void VisualizarCompraForm_Load(object sender, EventArgs e)
        {
            //Carrega os itens da compra selecionada para a DataGridView
            ControllerVisualizarCompra.MostrarItensCompra(dataGridViewItensCompra);
        }

        private void buttonAdicionarItemNaoP_Click(object sender, EventArgs e)
        {
            //Abre o formulário para adicionar itens não previstos à compra
            ControllerAdicionarItensNaoPrevistos.AbrirItensNaoPrevistosForm(ControllerVisualizarCompra.compraDevolvida);


            //Atualiza a datagridview ao sair do adicionar Itens não previstos
            ControllerVisualizarCompra.MostrarItensCompra(dataGridViewItensCompra);   
        }

        private void buttonFecharCompra_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

            ControllerVisualizarCompra.FecharCompra(out string mensagem);
=======
            //Variável que irá armazenar a mensagem de resultado
            string mensagem = "";

            //Tenta fechar a compra selecionada
            ControllerVisualizarCompra.FecharCompra(out mensagem);
>>>>>>> mariana

            //Apresenta ao utilizador o resultado da operação
            MessageBox.Show(mensagem);

            //Atualiza a lista de compras da página principal
            ControllerCompras.MostrarCompras(PaginaInicialForm.comprasPaginaPrincipal);
        }
    }
}
