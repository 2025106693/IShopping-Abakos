using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System.Linq;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    // Controller que trata da gestão dos Artigos (CRUD)
    internal class ControllerArtigo
    {
        // Fecha o form dos artigos e volta a mostrar a página principa
        public static void VoltarPaginaPrincipal()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
            ArtigosForm.instance.Close();
        }

        // Cria um novo artigo se ainda não existir com o mesmo nome
        public static void botaoAdicionar(string nome, string preco, string descricao, ComboBox tipoArtigo, out string mensagem)
        {

            decimal precoArtigo;
            int tipoArtigoId;

            // valida que escreveu nome
            if (nome == "")
            {
                mensagem = "Por favor insira um nome";
                return;
            }

            // valida que escreveu preço
            if (preco == "")
            {
                mensagem = "Por favor insira um preço";
                return;
            }
            // o preço vem como string, tem de ser convertido para decimal
            else if (!decimal.TryParse(preco, out precoArtigo))
            {
                mensagem = "O preco tem de ser numerico";
                return;
            }

            // tem de ter um tipo selecionado na combobox
            if (tipoArtigo.SelectedItem == null)
            {
                mensagem = "Por favor selecione um tipo de artigo.";
                return;
            }
            // Variavel que guarda id do objeto selecionado TipoArtigo  |
            // .SelectedValue devolve o ValueMember do "Id",
            tipoArtigoId = (int)tipoArtigo.SelectedValue;

            using (IShoppingContext db = new IShoppingContext())
            {
                // verifica se já existe algum artigo com aquele nome
                Artigo artigo = db.DBArtigos.FirstOrDefault(
                    o => o.Nome == nome);

                if (artigo == null)
                {
                    // se não existir, cria um novo
                    artigo = new Artigo()
                    {
                        Nome = nome,
                        Preco = precoArtigo,
                        Descricao = descricao,
                        TipoArtigoId = tipoArtigoId,

                    };
                    db.DBArtigos.Add(artigo);
                }
                else
                {
                    // se já existir, não deixa criar outro com o mesmo nome
                    mensagem = "Já existe este artigo!\nSe quiser alterar, clique no botão Editar Artigo";
                    return;
                }
                db.SaveChanges();
                mensagem = "Artigo criado com sucesso!";
            }
        }


        // Devolve os objetos do tipo TiposArtigo para listar na Combox
        public static void CarregarTiposArtigo(ComboBox comboBox)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                // vai buscar os tipos de artigo ordenados por id
                var tiposArtigo = db.DBTipoArtigos
                              .OrderBy(t => t.Id).ToList();

                comboBox.DataSource = tiposArtigo;
                comboBox.DisplayMember = "Nome"; // o que o utilizador vê
                comboBox.ValueMember = "Id"; // valor associado fica escondigo
                comboBox.SelectedIndex = -1; // começa sem nada selecionado
            }
        }

        // Atualiza a DataGridView com a lista de artigos
        public static void MostrarTabelaArtigos(DataGridView dataSource)
        {
            
            // Se mostrássemos o objeto inteiro apareciam coisas a mais (compras, etc)
            using (IShoppingContext db = new IShoppingContext())
            {
                var artigos = db.DBArtigos
            .OrderBy(o => o.Id)
            // Select para escolher só as colunas que queremos mostrar.
            .Select(o => new
            {
                o.Id,
                o.Nome,
                o.Preco,
                o.Descricao,
                // IdTipoArtigo e TipoArtigo é o nome da coluna que aparece
                // IdTipoArtigo = o.TipoArtigo.Id -->usado para debug
                TipoArtigo = o.TipoArtigo.Nome   // aqui aparece o nome em vez do Id
            })
            .ToList();

                dataSource.DataSource = artigos;

            }
        }

        // Apaga um artigo pelo Id
        public static void EliminarArtigos(string id, DataGridView dataSource, out string mensagem)
        {

            int idArtigo;

            // valida que escreveu Id
            if (id == "")
            {
                mensagem = "Por favor adicione um Id";
                return;
            }
            // valida que o Id é mesmo um número
            if (!int.TryParse(id, out idArtigo))
            {
                mensagem = "O id tem de ser numérico";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // vai buscar o artigo com aquele Id
                Artigo artigo = db.DBArtigos.FirstOrDefault(
                    a => a.Id == idArtigo);

                if (artigo != null)
                {
                    db.DBArtigos.Remove(artigo);
                    db.SaveChanges();
                    MostrarTabelaArtigos(dataSource); // atualiza a tabela

                    mensagem = "Artigo eliminado com sucesso";
                }
                else
                {
                    mensagem = "Artigo não encontrado. Verifique o id e tente novamente.";
                }
            }
        }


        // Altera os campos de um artigo, só altera os campos que vierem preenchidos
        public static void AlterarArtigo(DataGridView dataSource, string id, string nome, string preco, ComboBox tipoArtigoId, string descricao, out string mensagem)
        {
            int idArtigo;

            // valida que escreveu Id
            if (id == "") 
            {
                mensagem = "Por favor, adicione um Id";
                return;
            }
            else if (!int.TryParse(id, out idArtigo))
            {
                mensagem = "O id tem de ser numérico";
                return;
            }

            // tem que haver pelo menos um campo para alterar, senão não faz sentido
            if ((nome == "") && (preco == "") && (tipoArtigoId.SelectedItem == null) && (descricao == ""))
            {
                mensagem = "Indique pelo menos um campo para alterar";
                return;
            }

            // Variavel que guarda id do objeto selecionado TipoArtigo  |
            // .SelectedValue devolve o ValueMember do "Id",

            using (IShoppingContext db = new IShoppingContext())
            {

                Artigo artigo = db.DBArtigos.FirstOrDefault(a => a.Id == idArtigo);

                // só altera o que veio preenchido
                if (artigo != null)
                {
                    if (nome != "")
                    {
                        artigo.Nome = nome;
                    }
                    if (preco != "")
                    {
                        decimal precoArtigo;

                        if (!decimal.TryParse(preco, out precoArtigo))
                        {
                            mensagem = "O preco tem de ser numérico";
                            return;
                        }
                        artigo.Preco = precoArtigo;
                    }
                    if (tipoArtigoId.SelectedIndex != -1)
                    {
                        artigo.TipoArtigoId = (int)tipoArtigoId.SelectedValue;
                    }
                    if (descricao != "")
                    {
                        artigo.Descricao = descricao;
                    }
                }
                else
                {
                    mensagem = "ID do Artigo não encontrado!";
                    return;
                }
                db.SaveChanges();
                mensagem = "Artigo alterado com sucesso";
                MostrarTabelaArtigos(dataSource); // atualiza a tabela
            }
        }

        // Limpa os campos do form depois de qualquer operação
        public static void LimparCampos(TextBox nome, TextBox preco, ComboBox tipoArtigo, TextBox descricao, TextBox id, DataGridView dataSource)
        {
            nome.Text = "";             // coloca os campos a vazio
            preco.Text = "";
            tipoArtigo.SelectedIndex = -1;
            descricao.Text = "";
            id.Text = "";
            dataSource.ClearSelection(); // para retirar a selecao do cursor da tabela(datagridview)
        }
    }
}