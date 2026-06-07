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

namespace iShopping_Abakos.View
{
    // Formulário da gestão de Artigos (CRUD)
    // Toda a lógica está no ControllerArtigo, aqui só tratamos dos eventos dos botões
    public partial class ArtigosForm : Form
    {
        // Referência estática deste formulário para conseguirmos chamá-lo de outros sítios
        // (por exemplo no controller quando quer fechar a janela)
        public static ArtigosForm instance;
        public ArtigosForm()
        {
            InitializeComponent();
            instance = this;  // guarda a instância atual
        }

        // Botão Voltar - chama o controller que fecha este form e mostra a página principal
        private void button_Voltar_Click(object sender, EventArgs e)
        {
            ControllerArtigo.VoltarPaginaPrincipal();
        }


        // Quando o formulário é carregado (abre pela primeira vez)
        private void ArtigosForm_Load(object sender, EventArgs e)
        {
            // gera as colunas automaticamente a partir do que vem do controller
            dataGridViewArtigos.AutoGenerateColumns = true;
            dataGridViewArtigos.RowHeadersWidth = 60;

            // preenche a tabela com os artigos da BD
            ControllerArtigo.MostrarTabelaArtigos(dataGridViewArtigos);

            // tira a seleção inicial para a tabela começar sem nada selecionado
            dataGridViewArtigos.ClearSelection();
            // Para mostar os tipos de artigos guardados na tabela TipoArtigos
            // enche a combobox com os tipos disponíveis para o utilizador escolher
            ControllerArtigo.CarregarTiposArtigo(comboBoxTipoArtigo);
        }

        // Botão Adicionar - cria um novo artigo com os valores das textboxes
        private void button_AdicionarArtigo_Click_1(object sender, EventArgs e)
        {
            // chama o controller, passando os valores das caixas de texto e a combobox
            // .Trim() tira espaços no início/fim caso o utilizador tenha escrito mal
            // out string mensagem -> o controller devolve uma mensagem para mostrarmos
            ControllerArtigo.botaoAdicionar(textBoxNomeArtigo.Text.Trim(), textBox_Preco.Text, textBoxDescricaoArtigo.Text, comboBoxTipoArtigo, out string mensagem);

            // atualiza a tabela para mostrar o artigo novo
            ControllerArtigo.MostrarTabelaArtigos(dataGridViewArtigos);
            // mostra a mensagem ao utilizador (sucesso ou erro)
            MessageBox.Show(mensagem);
            // limpa todos os campos para a próxima operação
            ControllerArtigo.LimparCampos(textBoxNomeArtigo, textBox_Preco, comboBoxTipoArtigo, textBoxDescricaoArtigo, textBoxIDArtigo, dataGridViewArtigos);
        }

        // Botão Alterar - altera um artigo existente pelo id introduzido
        private void buttonAlterarArtigo_Click(object sender, EventArgs e)
        {
            // chama o controller com o id e os valores novos (campos vazios não são alterados)
            ControllerArtigo.AlterarArtigo(dataGridViewArtigos, textBoxIDArtigo.Text.Trim(), textBoxNomeArtigo.Text.Trim(), textBox_Preco.Text.Trim(), comboBoxTipoArtigo, textBoxDescricaoArtigo.Text.Trim(), out string mensagem);
            // mostra ao utilizador se correu bem ou não
            MessageBox.Show(mensagem);
            // limpa os campos no fim
            ControllerArtigo.LimparCampos(textBoxNomeArtigo, textBox_Preco, comboBoxTipoArtigo, textBoxDescricaoArtigo, textBoxIDArtigo, dataGridViewArtigos);
        }

        // Botão Eliminar - apaga o artigo com o id introduzido
        private void buttonEliminarArtigo_Click(object sender, EventArgs e)
        {
            // chama o controller, que valida o id e apaga o artigo
            ControllerArtigo.EliminarArtigos(textBoxIDArtigo.Text.Trim(), dataGridViewArtigos, out string mensagem);
            // mostra a mensagem ao utilizador
            MessageBox.Show(mensagem);
            // limpa os campos
            ControllerArtigo.LimparCampos(textBoxNomeArtigo, textBox_Preco, comboBoxTipoArtigo, textBoxDescricaoArtigo, textBoxIDArtigo, dataGridViewArtigos);
        }
    }
}