using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerTiposArtigo
    {
        public static void VoltarPaginaPrincipal()      // no botão voltar
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Show();   //ao clicar no botão voltar, chamamos a instância criada na PaginaInicialForm
            TipoArtigoForm.tipoArtigoForm.Close();              //e mostra o Form com Show, porque ela foi definida primeiro com Hide(escondida)
        }                                                      //de seguida fechamos o form com a instância criada no TipoArtigoForm (fazendo
                                                              //assim a ligacao)

        
        public static void AdicionarTipoArtigo(string nome, string descricao)
        {
            if (nome == "") // uma validacão para obrigar o utilizador a inserir um nome
            {
                MessageBox.Show("Insira um nome.\n(Descricao não é obrigatória)");
                return;
            }


            // DESCRIÇÃO NÃO É OBRIGATÓRIA

            //ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())  // usamos uma instância por operação sempre que quisermos acessar à DB
            {
                TipoArtigo tipoArtigo = db.DBTipoArtigos.FirstOrDefault(o => o.Nome == nome); // criamos uma variavel do tipo TipoArtigo e 
                                 // procura na base de dados o primeiro tipo de artigo em que o Nome é igual ao valor da variável nome

                if (tipoArtigo == null) // validação, se o tipoArtigo não existir
                {
                    tipoArtigo = new TipoArtigo() // criamos um objeto do tipo TipoArtigo
                    {
                        Nome = nome,            // atribuimos os valores/textos passados pelos inputs do utilizador (nas textboxs)
                        Descricao = descricao
                    };

                    db.DBTipoArtigos.Add(tipoArtigo);  // adicionamos à base de dados
                }

                //não permitimos que exista duplicação de tipos de artigo

                else  // caso não seja null significa que já existe
                {
                    MessageBox.Show("Já existe esse tipo de artigo criado!"); 
                    return;
                }

                db.SaveChanges();  // gravamos na base de dados as alteracoes
            }
        }



        public static void MostrarTabelaTipoArtigo(DataGridView dataSource)
        {
            using(IShoppingContext db = new IShoppingContext())
            {
                dataSource.DataSource = db.DBTipoArtigos.OrderBy(o => o.Id).Select(t => new
                {
                    //Selecionamos os campos a serem apresentados
                    t.Id,
                    t.Nome,
                    t.Descricao,

                }).ToList();
            }

            // nesta função, criamos novamente uma nova instância (db) e vamos à base de dados buscar os valores atuais das tabelas
            // imprimindo na datagridview com ToList e ordenando pelo id forma ascendente
        }



        public static void AlterarTipoArtigo(string id, string nome, string descricao, DataGridView dataSource)
        {
            int id_tipoArtigo;

            if(nome == "" && descricao == "") // validação, obriga a escrever um nome ou uma descricao para alterar a informação
            {
                MessageBox.Show("Insira um nome ou uma descricao");
                return;
            }

            if(id == "")  // validação, obriga o utilizador a escrever um id
            {
                MessageBox.Show("Insira um ID");
                return;
            }

            if(!int.TryParse(id, out id_tipoArtigo))  // o id vem como string, com o tryparse convertemos para int e atribuimos ao id_tipoArtigo
            {                                         // o int obriga que seja um valor numérico
                MessageBox.Show("O ID tem de ser numérico");
                return;
            }

            
            using (IShoppingContext db = new IShoppingContext()) // a mesma estratégia do método AdicionarTipoArtigo
            {
                TipoArtigo tipoArtigo = db.DBTipoArtigos.FirstOrDefault(o => o.Id == id_tipoArtigo);

                if(tipoArtigo != null) // validação, se o tipoArtigo existir...
                {
                    if(nome != "")     // validação, se o nome inserido nao estiver vazio
                    {
                        tipoArtigo.Nome = nome;  // atribui o que foi introduzido ao objeto
                    }
                    if(descricao != "")
                    {
                        tipoArtigo.Descricao = descricao;
                    } 
                }
                else   // validação, caso seja null ...
                {
                    MessageBox.Show("ID do Tipo de Artigo não encontrado!");
                    return;
                }

                db.SaveChanges();   // grava as alterações na base de dados (atualiza)

                MessageBox.Show("Tipo de Artigo alterado com sucesso");

                MostrarTabelaTipoArtigo(dataSource);   // chamamos a função mostrartabela para atualizar a datagridview
            }
        }



        public static void EliminarTipoArtigo(string id, DataGridView dataSource)
        {
            int id_tipoArtigo;


            if(id == "")  // validações, caso esteja vazio
            {
                MessageBox.Show("Indique o ID do Tipo de Artigo");
                return;
            }

            if(!int.TryParse(id, out id_tipoArtigo))  // obriga a introduzir um inteiro e converte com Tryparse para inteiro, porque
            {                                         // vem como string, guarda na variável id_tipoArtigo
                MessageBox.Show("O ID tem de ser numérico!");
                return;
            }



            // vamos procurar à base de dados e verificamos se o id que introduzimos existe na base de dados, caso não exista
            // imprime uma mensagem de aviso
            using (IShoppingContext db = new IShoppingContext())
            {
                TipoArtigo tipoArtigo = db.DBTipoArtigos.FirstOrDefault(o => o.Id == id_tipoArtigo);

                if(tipoArtigo == null)
                {
                    MessageBox.Show("Tipo de Artigo não existente");
                    return;   
                }


                
                db.DBTipoArtigos.Remove(tipoArtigo); // remove da BD
                db.SaveChanges();                   // guarda alterações

                MessageBox.Show("Tipo de Artigo removido com sucesso!");
                MostrarTabelaTipoArtigo(dataSource);  // para atualizar a datagridview
                
            }
        }
        
        // função usada para apagar os campos preenchidos no fim de qualquer Adicionar, Alterar ou Remover
        // foi passado apenas o nome das textbox portanto aqui atribuimos aos parâmetros do tipo TextBox
        public static void LimparCampos(TextBox nome, TextBox descricao, TextBox id, DataGridView dataSource)
        {
            nome.Text = "";             // coloca os campos a vazio
            descricao.Text = "";
            id.Text = "";
            dataSource.ClearSelection(); // para retirar a selecao do cursor da tabela(datagridview)
        }
    }
}
