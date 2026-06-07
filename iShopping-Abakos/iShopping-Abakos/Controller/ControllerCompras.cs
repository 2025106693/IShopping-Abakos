using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    //Controller responsável pela compra : criar, editar, adicionar itens previstos e eliminar compra
    internal class ControllerCompras 
    {
        
        //Fecha o form de compras e reexibe a página principal (que estava em hide)
        public static void VoltarPaginaPrincipal()
        {
            ComprasForm.instance.Close();
            PaginaInicialForm.instanciaPaginaPrincipal.Show(); 
        }

        //Carrega as compras na DataGridView, ordenadas por Data de criação
        //Função usada também para atualizar/carregar a DataGridView cada vez que a tabela compras muda
        //ou quando são adicionados itens
        public static void MostrarCompras(DataGridView dataSource)
        {    
            //Verifica se a grelha foi passada corretamente
            if (dataSource == null)
            {
                return;
            }

            //Por cada operação usa-se sempre o novo IShoppingContext
            //ToList() materializa os dados e evita lazy loading/inconsistências
            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura todas as compras abertas na tabela das compras
                var compras = db.DBCompras.Where(c => c.Fechado == false).OrderBy(c => c.Id).ToList();

                if (compras.Any())
                {
                    foreach (var compra in compras)
                    {
                        compra.TotalPrevisto = ObterTotalPrevisto(compra.Id);
                    }

                    db.SaveChanges();
                    //Apresenta as compras
                    dataSource.DataSource = compras;
                }


                //Se encontrar compras abertas obtém o total previsto e atualiza o total previsto
                //Função 2 em 1 (carrega as compras e caso o utilizador adicione algum item atualiza os dados)

            }
        }

        // Cria um registo de compra a partir dos inputs da view; 'mensagem' devolve o resultado
        public static void CriarCompra(string nomeCompra, string descricao, out string mensagem)
        {

            mensagem = ""; // variável mensagem que irá mudar consoante o resultado da função e validações

            if (nomeCompra == "") //para haver um registo de compra tem que haver obrigatoriamente um nome.
                                  
            {
                mensagem = "Precisa de inserir o campo nome compra!";
                return;
            }

            //como a descricao não é obrigatória.Não criamos nenhuma validação.
            //O utilizador escolhe o que fazer para a descrição. 

            using (IShoppingContext db = new IShoppingContext()) //nova instância da base de dados
            {
                //vamos à base de dados e fazemos a pesquisa se existe já alguma compra com o mesmo nome (não são permitidos nomes duplicados)
                
                Compra compra = db.DBCompras.FirstOrDefault(c => c.NomeCompra == nomeCompra);

                if (compra == null) // caso não haja já uma compra com o mesmo nome, adicionamos a compra com os inputs do utilizador
                                    // e toda a informação extra como datas e o utilizador
                {
                    compra = new Compra()
                    {
                        NomeCompra = nomeCompra,
                        Descricao = descricao,
                        DataCriacao = DateTime.Now,
                        CriadoPor = Sessao.UtilizadorAtual, //utilizador atua (estático) ou seja, aquele que está logado                                         
                        Fechado = false,
                        TotalPrevisto = 0,

                        //quando um utilizador cria uma compra ainda não tem itens (sendo inicializado a 0)
                        //a compra ainda não foi realizada iniciando o fechado como false
                        //o utilizador tem de criar primeiro a compra e depois fechá-la após essa operação

                        TotalGasto = 0 //Só irá ter um valor final quando a compra for fechada
                        //quando for para fechar então soma-se todo o valor dos itens compra + qualquer imprevisto/alteração de quantidades
                    };


                    db.DBCompras.Add(compra);
                    mensagem = "Compra adicionada com sucesso!"; // mensagem para o utilizador saber se foi realizada a ação com sucesso
                }
                else
                {
                    mensagem = "Compra existente, introduza um nome diferente!";
                    return; //obriga a utilizar um nome diferente. Nenhuma compra pode ter o mesmo nome!
                }

                db.SaveChanges(); //guarda as alterações caso corra tudo bem
            }

        }

        //Altera as informações de uma compra selecionada (através do id) com novos inputs da View
        public static void EditarInformacoesCompra(string id, string nomeCompra, string descricao, out string mensagem)
        {
            mensagem = ""; //mensagem varia consoante o resultado 
            int idCompra; // variável para validação do id

            //Validação se o utilizador introduziu um id (É obrigatório)
            if (id == "")
            {
                mensagem = "Introduza o ID";
                return;
            }

            //Validação: o Id tem de ser númerico
            if (!int.TryParse(id, out idCompra)) 
            {
                mensagem = "O ID tem de ser numérico!";
                return;

            }


            if ((nomeCompra == "") && (descricao == "")) //Tem de haver algum input para realizar a operação de alterar informações.
            {
                mensagem = "Introduza informações (nome/descrição) para realizar a alteração!";
                return;
            }

            using (IShoppingContext db = new IShoppingContext()) //nova instância especifica para a operação
            {
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra && c.Fechado == false); // realiza a pesquisa pelo ID

                if (compra == null) // Caso não encontre, o utilizador tem de voltar a introduzir um ID que exista
                {
                    mensagem = "Compra inexistente, indique um ID válido de uma compra!";
                    return;
                }

                else // altera a informação da compra com o id que o utilizador inseriu
                {
                    if (descricao != "")
                    {
                        compra.Descricao = descricao;
                    }

                    if (nomeCompra != "")
                    {
                        compra.NomeCompra = nomeCompra;
                    }

                    //Regista quem alterou e quando
                    compra.AlteradoPor = Sessao.UtilizadorAtual;
                    compra.DataAlteracao = DateTime.Today;

                    db.SaveChanges(); //guarda alterações
                    mensagem = "Compra alterada com sucesso!"; //Apresenta uma mensagem de sucesso
                }
                ;
            }
        }

        //Calcula e guarda o total gasto de uma compra (total previsto + itens não previstos)
        public static decimal ObterTotalGastoCompra(int compraId)
        {

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura a compra pelo Id
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == compraId);

                //Caso a compra correspondente ao ID não exista
                if (compra == null)
                {
                    return 0;
                }

                //Obtém os itens não previstos da compra selecionada/indicada
                var itensNaoPrevistos = db.DBItensCompra.OfType<ItemNaoPrevisto>()
                                        .Where(i => i.CompraId == compraId).ToList();

                //Se existir itens não previstos calcula o total gasto também com o somatório dos itens previstos (Total Previsto)
                if (itensNaoPrevistos.Any())
                {
                    compra.TotalGasto = compra.TotalPrevisto + itensNaoPrevistos.
                        Sum(i => i.Quantidade * i.PrecoUnitario);
                }

                //Senão o total gasto é igual ao previsto (pois não houve a adição de nenhum item não previsto)
                else
                {
                    compra.TotalGasto = compra.TotalPrevisto;
                }

                //Guarda as alterações na bd
                db.SaveChanges();

                return compra.TotalGasto; //Devolve o total gasto (de forma a ser utilizado em várias funcionalidades)
            }
        }
        
        //Obtém o Total Previsto
        public static decimal ObterTotalPrevisto(int compraId)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura a compra pelo Id
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == compraId);

                //Caso a compra correspondente ao ID não exista
                if (compra == null)
                {
                    return 0;
                }

                //Obtém os itens previstos da compra selecionada/indicada
                var itensPrevistos = db.DBItensCompra.OfType<ItemPrevisto>()
                                        .Where(i => i.CompraId == compraId).ToList();

                //Se existir itens previstos calcula o total previsto
                if (itensPrevistos.Any())
                {

                    compra.TotalPrevisto = itensPrevistos.Sum(i => i.PrecoUnitario * i.QuantPrevista);
  
                }

                //Senão houver itens então o valor é 0
                else
                {
                    compra.TotalPrevisto = 0;
                }

                //Guarda as alterações na bd
                db.SaveChanges();
                return compra.TotalPrevisto; //Devolve o total previsto (de forma a ser utilizado em várias funcionalidades)
            }

               
        }


        //Elimina uma compra (e os seus itens) a partir do ID indicado pelo utilizador
        public static void EliminarCompra(string id, out string mensagem)
        {
            mensagem = "";
            int idCompra;

            //Verifica se um ID foi inserido
            if (id == "")
            {
                mensagem = "Tem de introduzir um id";
                return;
            }

            //Verifica se o ID é numérico
            if (!int.TryParse(id, out idCompra))
            {
                mensagem = "O id tem de ser numérico";
                return;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura o ID da compra e verifica que está aberta (só elimina compras ainda abertas)
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra && c.Fechado == false);

                //Se encontrar uma compra
                if (compra != null)
                {
                    //Vai buscar os itens associados
                    var ItensCompra = db.DBItensCompra.Where(i => i.CompraId == idCompra).ToList();

                    //Caso haja itens 
                    if (ItensCompra.Any())
                    {
                        //Remove os itens associados
                        foreach (var item in ItensCompra)
                        {
                            db.DBItensCompra.Remove(item);
                        }
                    }
                    
                    //Remove a compra
                    db.DBCompras.Remove(compra);

                    //Salva as alterações na base de dados
                    db.SaveChanges();
                    mensagem = "Compra removida com sucesso!";
                    
                }

                //Caso a compra não exista (o ID introduzido não corresponda a nenhuma)
                else
                {
                    mensagem = "Introduza uma compra existente";
                    return;
                }
            }
        }


        //Devolve uma compra a partir do ID (usada para abrir o forms/métodos que necessitam de uma compra associada)
        public static Compra DevolverCompra(string id, out string mensagem)
        {
            int idCompra;

            //Verifica que um ID foi introduzido
            if (id == "")
            {
                mensagem = "Por favor insira um Id";
                return null;
            }

            //Verifica que o ID é numérico
            if (!int.TryParse(id, out idCompra))
            {
                mensagem = "O Id tem de ser numérico";
                return null;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura a compra através do id
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra);

                //Garante que é uma compra existente e que está aberta
                if (compra != null && compra.Fechado == false)
                {
                    mensagem = "";
                    return compra;
                }
                
                //caso não exista
                else if (compra == null)
                {
                    mensagem = "Selecione uma compra existente!";
                    return null;
                }

                //caso esteja fechada
                else
                {
                    mensagem = "A compra já se encontra fechada";
                    return null;
                }
            }
        }


        //Limpa os campos do Formulário e tira a seleção da grelha
        public static void LimparCampos(TextBox nome, TextBox descricao, TextBox id, DataGridView dataSource)
        {
            nome.Text = "";             
            descricao.Text = "";
            id.Text = "";
            dataSource.ClearSelection(); 
        }
    }
}
