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
    public partial class TipoArtigoForm : Form
    {

        // criamos uma variavel do tipo do propio TipoArtigoForm
        public static TipoArtigoForm tipoArtigoForm;
        public TipoArtigoForm()
        {
            InitializeComponent();
            tipoArtigoForm = this;      // apontamos a instancia para ela propria e é a partir daqui que vamos andar a viajar para outros forms
            
        }

        private void button_Voltar_Click(object sender, EventArgs e)  // botao voltar
        {
            ControllerTiposArtigo.VoltarPaginaPrincipal();  // chamamos a funcao que está implementada em ControllerTipoArtigo.cs
        }

        private void buttonAdicionarTipoArtigo_Click(object sender, EventArgs e)   // botao adicionar
        {
            ControllerTiposArtigo.AdicionarTipoArtigo(textBoxNomeTipoArtigo.Text.Trim(), textBoxDescricaoTipoArtigo.Text.Trim()); // chamamos a funcao do ControllerTiposArtigo.cs passando o nome e descricao como parametros
            ControllerTiposArtigo.MostrarTabelaTipoArtigo(dataGridViewTipoArtigos);   // e aqui passando a tabela datagridview, para 
                                                                                      // posteriormente atualizar a tabela após alteracoes
            ControllerTiposArtigo.LimparCampos(textBoxNomeTipoArtigo, textBoxDescricaoTipoArtigo, textBoxIDtipoArtigo,
                                                                                        dataGridViewTipoArtigos);
            // chamamos a funcao do Controller passando todos os campos que podem ser preenchidos e tambem a tabela dos tipos de artigos
            // esta funcao server apenas para apagar os campos preenchidos e retirar a selecao de uma linha da tabela datagridview
            // a seguir ao adicionar um tipo de artigo

        }

        private void buttonAlterarTipoArtigo_Click(object sender, EventArgs e)  // botao alterar
        {
            ControllerTiposArtigo.AlterarTipoArtigo(textBoxIDtipoArtigo.Text.Trim(), textBoxNomeTipoArtigo.Text.Trim(),
                                                        textBoxDescricaoTipoArtigo.Text.Trim(), dataGridViewTipoArtigos);
            // chamamos a funcao AtlerarTipoArtigo do controller passando os paramentros de todas as caixas de texto (que vão como string) e a datagridview(tabela) para posteriormente atualizar a tabela após alteracoes

            ControllerTiposArtigo.LimparCampos(textBoxNomeTipoArtigo, textBoxDescricaoTipoArtigo, textBoxIDtipoArtigo, dataGridViewTipoArtigos);
            // chamamos a funcao limparCampos novamente...
        }

        private void TipoArtigoForm_Load(object sender, EventArgs e) // este método carrega quando o form abre(evento load)
        {
            dataGridViewTipoArtigos.AutoGenerateColumns = true; // cria colunas automaticamente com base nas propriedades da base de dados
            dataGridViewTipoArtigos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // automatiza o tamanho das colunas consoante o tamanho do texto introduzido
            ControllerTiposArtigo.MostrarTabelaTipoArtigo(dataGridViewTipoArtigos); // carrega os dados na datagridview já inseridos na AppDbInitializer com as colunas já definidas na base de dados
            dataGridViewTipoArtigos.ClearSelection(); // remove/apaga selecao do cursor
        }

        private void buttonEliminarTipoArtigo_Click(object sender, EventArgs e) // botao eliminar
        {
            ControllerTiposArtigo.EliminarTipoArtigo(textBoxIDtipoArtigo.Text.Trim(), dataGridViewTipoArtigos);
            // chamamos a funcao eliminar do controller passando apenas o ID (que é o unico paramentro preciso para eliminar) e a datagridview para posteriormente atualizar a tabela após alteracoes

            ControllerTiposArtigo.LimparCampos(textBoxNomeTipoArtigo, textBoxDescricaoTipoArtigo, textBoxIDtipoArtigo, dataGridViewTipoArtigos);
        }
    }
}
