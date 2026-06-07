using iShopping_Abakos.Controller;
using System;
using System.Windows.Forms;

namespace iShopping_Abakos.View
{
    public partial class ComprasForm : Form
    {
        // DataGridView utilizada para apresentar as compras registadas
        public static DataGridView dataGridView;

        // Instância do formulário para acesso a partir de outras classes
        public static ComprasForm instance;
        public ComprasForm()
        {
            InitializeComponent();

            // Guarda a instância atual do formulário
            instance = this;

            // Associa a DataGridView à variável estática
            dataGridView = dataGridView_Compras;
        }



        private void button_Voltar_Click(object sender, EventArgs e)
        {
            // Atualiza a listagem de compras na página principal
            ControllerPaginaInicial.MostrarEstadoCompras(0, PaginaInicialForm.comprasPaginaPrincipal);

            // Regressa à página principal
            ControllerCompras.VoltarPaginaPrincipal();
        }



        private void ComprasForm_Load(object sender, EventArgs e)
        {
            // Ativa a geração automática de colunas
            dataGridView_Compras.AutoGenerateColumns = true;

            // Define a largura da coluna dos cabeçalhos das linhas
            dataGridView_Compras.RowHeadersWidth = 60;

            // Carrega as compras registadas
            ControllerCompras.MostrarCompras(dataGridView_Compras);

            // Remove qualquer seleção inicial da DataGridView
            dataGridView_Compras.ClearSelection();
        }



        private void button_CriarCompra_Click(object sender, EventArgs e)
        {
            // Cria uma nova compra com os dados introduzidos
            ControllerCompras.CriarCompra(textBox_Nome.Text.Trim(), textBox_Descricao.Text.Trim(), out string mensagem);

            //// Apresenta o resultado da operação
            MessageBox.Show(mensagem);

            // Atualiza a listagem de compras
            ControllerCompras.MostrarCompras(dataGridView_Compras);

            // Limpa os campos do formulário
            ControllerCompras.LimparCampos(textBox_Nome, textBox_Descricao, textBox_ID, dataGridView_Compras);
        }



        private void button_AlterarInfo_Click(object sender, EventArgs e) // botão para alterar informações de compra
        {
            // Altera as informações da compra selecionada
            ControllerCompras.EditarInformacoesCompra(textBox_ID.Text.Trim(), textBox_Nome.Text.Trim(), textBox_Descricao.Text.Trim(), out string mensagem);
            
            //Apresenta o resultado da operação 
            MessageBox.Show(mensagem);
            
            //Atualiza a listagem de compras
            ControllerCompras.MostrarCompras(dataGridView_Compras);
            
            //Limpa os campos
            ControllerCompras.LimparCampos(textBox_Nome, textBox_Descricao, textBox_ID, dataGridView_Compras);
        }



        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            //Elimina a compra selecionada
            ControllerCompras.EliminarCompra(textBox_ID.Text.Trim(), out string mensagem); 
            
            //Apresenta o resultado da operação
            MessageBox.Show(mensagem);
            
            //Atualiza a listagem de compras
            ControllerCompras.MostrarCompras(dataGridView_Compras);
            
            //Limpa os campos
            ControllerCompras.LimparCampos(textBox_Nome, textBox_Descricao, textBox_ID, dataGridView_Compras);
        }



        private void button_AdicionarItem_Click(object sender, EventArgs e)
        {
            //Obtém a compra correspondente ao ID introduzido
            Compra compra = ControllerCompras.DevolverCompra(textBox_ID.Text.Trim(), out string mensagem);

            //Caso exista uma mensagem de erro, apresenta ao utilizador
            if (!string.IsNullOrEmpty(mensagem))
            MessageBox.Show(mensagem);
            
            //Abre o formulário para adicionar itens previstos à compra selecionada
            ControllerAdicionarItensPrevistos.AbrirAdicionarItensPrevistosForm(compra);

            //Limpa os campos
            ControllerCompras.LimparCampos(textBox_Nome, textBox_Descricao, textBox_ID, dataGridView_Compras);
        }
    }
}
