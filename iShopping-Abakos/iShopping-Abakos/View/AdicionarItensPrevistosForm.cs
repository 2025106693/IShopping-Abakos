using iShopping_Abakos.Controller;
using System;
using System.Windows.Forms;

namespace iShopping_Abakos.View
{
    public partial class AdicionarItensPrevistosForm : Form
    {
        // Label utilizada para apresentar o nome da compra selecionada
        public static Label labelNome;

        // Label utilizada para apresentar o valor total previsto da compra
        public static Label labelPrevisto;
        public AdicionarItensPrevistosForm()
        {
            InitializeComponent();

            //Associa os labels do formulário às variáveis estáticas
            labelNome = label_NomeCompra;
            labelPrevisto = label_TotalPrevisto;
        }

        private void button_Voltar_Click(object sender, EventArgs e)
        {
            //Atualiza a listagem de compras
            ControllerCompras.MostrarCompras(ComprasForm.dataGridView);

            //Volta a apresentar o formulário de compras
            ComprasForm.instance.Show();

            //Fecha o formulário atual
            this.Close();
            
        }

        // Botão Adicionar - adiciona um item previsto à compra atual
        private void button_AdicionarItem_Click(object sender, EventArgs e)
        {
            // validação - tem de haver um artigo selecionado na combobox
            if (comboBox2_Artigos.SelectedValue == null)
            {
                MessageBox.Show("Selecione um artigo!");
                return;
            }
            // vai buscar o id do artigo selecionado (o ValueMember é "Id")
            int artigoId = (int)comboBox2_Artigos.SelectedValue;
            // vai buscar o valor do numericUpDown (quantidade prevista)
            int qtdPrevista = (int)numericUpDown1.Value;
            // chama o controller que faz a adição e devolve mensagem (sucesso ou erro)
            string mensagem;
            ControllerAdicionarItensPrevistos.AdicionarItemPrevisto(artigoId, qtdPrevista, out mensagem);
            // mostra a mensagem ao utilizador
            MessageBox.Show(mensagem);
            // atualiza a tabela para aparecer o item novo
            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);

        }

        // Quando o formulário é carregado pela primeira vez
        private void AdicionarItensPrevistosForm_Load(object sender, EventArgs e)
        {
            // enche a combobox dos tipos de artigo
            ControllerAdicionarItensPrevistos.CarregarTiposArtigo(comboBox_TiposArtigos);
            // mostra os itens previstos que já estão nesta compra
            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);
            // começa sem nada selecionado na combobox dos tipos
            comboBox_TiposArtigos.SelectedIndex = -1;

        }

        // Quando o utilizador escolhe um tipo de artigo na combobox, filtra os artigos
        private void comboBox_TiposArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // se ainda não há nada selecionado, sai
            if (comboBox_TiposArtigos.SelectedValue == null) return;
            // tenta converter o valor selecionado em int (id do tipo)
            // se falhar, sai sem fazer nada
            if (!(comboBox_TiposArtigos.SelectedValue is int tipoArtigoId)) return;

            // valida que o id é válido (diferente de 0)
            if (tipoArtigoId == 0)
            {
                MessageBox.Show("Selecione um tipo de artigo");
                return;
            }

            // carrega na segunda combobox apenas os artigos do tipo escolhido
            ControllerAdicionarItensPrevistos.CarregarArtigos(comboBox2_Artigos, tipoArtigoId);

        }

        // Botão Apagar - elimina o item previsto com o id introduzido
        private void button_ApagarItem_Click(object sender, EventArgs e)
        {
            // chama o controller que apaga o item, o id vem da textbox
            ControllerAdicionarItensPrevistos.EliminarItem(textBox_ID.Text.Trim(), out string mensagem);
            // mostra a mensagem (sucesso ou erro)
            MessageBox.Show(mensagem);
            // atualiza a tabela para o item desaparecer
            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);
        }


        // Botão Alterar Quantidade - muda a quantidade prevista de um item já existente
        private void button_AlterarQuantidade_Click(object sender, EventArgs e)
        {
            // chama o controller, passa o id (da textbox) e a nova quantidade (do numericUpDown)
            ControllerAdicionarItensPrevistos.AlterarQuantidade(textBox_ID.Text.Trim(), (int)numericUpDown1.Value, out string mensagem);
            // mostra mensagem
            MessageBox.Show(mensagem);
            // atualiza a tabela com a nova quantidade
            ControllerAdicionarItensPrevistos.MostrarListaItens(dataGridView_ItensPrevistos);
        }
    }
}
