using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
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
        public static void MostrarCompras(DataGridView dataSource)
        {
            //Por cada operação usa-se sempre o novo IShoppingContext
            //ToList() materializa os dados e evita lazy loading/inconsistências
            using (IShoppingContext db = new IShoppingContext())
            {
                var compras = db.DBCompras.OrderBy(c => c.Id).ToList();

                foreach (var compra in compras)
                {
                    compra.TotalPrevisto = ControllerCompras.ObterTotalPrevisto(compra.Id);
                }

                db.SaveChanges();
                dataSource.DataSource = compras;

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
                    mensagem = "Compra adicionada com sucesso!"; // mensagem para o utilizador saber se correu bem
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

            if (!int.TryParse(id, out idCompra)) //Se o id não for númerico, obriga a reintroduzir
            {
                mensagem = "O id tem de ser numérico!";
                return;

            }

            if ((nomeCompra == "") && (descricao == "")) //Tem de haver algum input para realizar a operação de alterar informações.
            {
                mensagem = "Tem de introduzir informações para realizar a alteração!";
                return;
            }



            using (IShoppingContext db = new IShoppingContext()) //nova instância especifica para a operação
            {
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra); // realiza a pesquisa pelo ID

                if (compra == null) // Caso não encontre, o utilizador tem de voltar a introduzir um ID que exista
                {
                    mensagem = "Compra inexistente, selecione uma compra!";
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

                    compra.AlteradoPor = Sessao.UtilizadorAtual;
                    compra.DataAlteracao = DateTime.Today;

                    db.SaveChanges(); //guarda alterações
                    mensagem = "Compra alterada com sucesso!";
                }
                ;
            }
        }

        //função para fechar Compra
        public static void FecharCompra(string id, out string mensagem)
        {
            mensagem = "";
            int idCompra;

            if (id == "")
            {
                mensagem = "Tem de introduzir um id";
                return;
            }

            if (!int.TryParse(id, out idCompra))
            {
                mensagem = "O id tem de ser númerico!";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra);

                if ((compra != null) && (compra.Fechado == false))
                {
                    compra.Id = idCompra;
                    compra.FechadoPor = Sessao.UtilizadorAtual;
                    compra.DataFecho = DateTime.Today;
                    compra.Fechado = true;
                    compra.TotalGasto = ObterTotalGastoCompra(idCompra);
                    db.SaveChanges();
                    mensagem = "Compra fechada com Sucesso!";

                }

                else
                {
                    if(compra == null)
                    {
                        mensagem = "Introduza uma compra existente!";
                        return;
                    }

                    if (compra.Fechado == true)
                    {
                        mensagem = "A compra já se encontra fechada!";
                        return;
                    }
                }
            }
        }

        public static decimal ObterTotalGastoCompra(int idCompra)
        {
            // a validação do idCompra é já realizada nas outras funções não sendo necessário realizar novamente
            //esta função serve apenas para calcular


            using (IShoppingContext db = new IShoppingContext())
            {
                {
                    return db.DBItensCompra.Where(i => i.CompraId == idCompra)
                                           .Sum(i => i.Quantidade * i.PrecoUnitario);

                }
                    
            }
        }

        public static decimal ObterTotalPrevisto(int idCompra)
        {
            // a validação do idCompra é já realizada nas outras funções não sendo necessário realizar novamente
            //esta função serve apenas para calcular

            using (IShoppingContext db = new IShoppingContext())
            {
                {
                   return  db.DBItensCompra.OfType<ItemPrevisto>()
                               .Where(i => i.CompraId == idCompra)
                               .Sum(i => i.PrecoUnitario * i.QuantPrevista);
                    
                }
            }
        }

        public static void EliminarCompra(string id, out string mensagem)
        {
            mensagem = "";
            int idCompra;

            if (!int.TryParse(id, out idCompra))
            {
                mensagem = "O id tem de ser numérico";
                return;
            }

            if (id == "")
            {
                mensagem = "Tem de introduzir um id";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra);

                if (compra != null)
                {
                    db.DBCompras.Remove(compra);
                    db.SaveChanges();
                    mensagem = "Compra removida com sucesso!";
                    
                }

                else
                {
                    mensagem = "Introduza uma compra existente";
                    return;
                }
            }
        }

        public static Compra DevolverCompra(string id)
        {
            int idCompra;


            if (id == "")
            {
                MessageBox.Show("Por favor insira um Id");
                return null;
            }

            if (!int.TryParse(id, out idCompra))
            {
                MessageBox.Show("O Id tem de ser numérico");
                return null;
            }


            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra);

                if (compra != null)
                {
                    return compra;
                }
                else
                {
                    MessageBox.Show("Selecione uma compra existente!");
                    return null;
                }
            }
        }

    }
}
