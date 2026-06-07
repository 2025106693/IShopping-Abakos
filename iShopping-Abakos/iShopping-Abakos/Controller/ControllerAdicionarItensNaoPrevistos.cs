using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System.Linq;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    //Controller responsável pela getão de itens Não Previstos de uma compra:
    //Estes são adicionados no momento da compra
    internal class ControllerAdicionarItensNaoPrevistos
    {
        //Compra devolvida através da seleção do ID na página principal
        public static Compra compraDevolvida;

        public static void AbrirItensNaoPrevistosForm(Compra compra)
        {
            //Verifica se a compra foi devolvida com sucesso 
            if (compra == null)
            {
                return;
            }
            else
            {
                //guarda a compra para ser partilhada por todos os métodos (rápido acesso)
                compraDevolvida = compra; 
                
                //esconde a página principal e abre o formulário de adicionar itens não previstos
                //da compra recebida
                VisualizarCompraForm.instance.Hide();
                AdicionarItensNaoPrevistosForm form = new AdicionarItensNaoPrevistosForm();

                //Preenche a label do nome da compra e do total gasto (valor que só é finalizado após fechar a compra)
                AdicionarItensNaoPrevistosForm.labelNome.Text = compra.NomeCompra;
                AdicionarItensNaoPrevistosForm.labelValorTotal.Text = "Total da compra: " + (ControllerCompras.ObterTotalGastoCompra(compraDevolvida.Id)).ToString() + "€";
                
                form.ShowDialog(); //Abre o formulário, já com todas as informações

                //NOTA: O total gasto representa o valor total de todos os itens (previstos + não previstos),
                //enquanto que o total previsto é apenas com o total dos itens previstos.

             
            }
        }


        //Método responsável por adicionar itens não previstos à compra atual
        
        public static void AdicionarItemNaoPrevisto(int artigoId, int quantidade, string descricao, out string mensagem)
        {
            mensagem = "";

            //Garante que existe a compra selecionada e armazenada
            //(Evita NullReferenceExcepcion ao aceder a compraDevolvida.Id)
            if (compraDevolvida == null)
            {
                mensagem = "Erro a carregar a compra selecionada!";
                return;
            }

            //Validação para o artigo, tem de haver uma seleção
            if (artigoId <= 0)
            {
                mensagem = "Selecione um artigo!";
                return;
            }

            // Validação da quantidade, esta tem de ser positiva
            if (quantidade <= 0)
            {
                mensagem = "A quantidade tem que ser maior que 0!";
                return;
            }

            //A descrição (observação) num item não previsto é obrigátória 
            //porque é a justificação da aquisição do mesmo
            
            if(descricao == "")
            {
                mensagem = "Deve de justificar o porquê de adquirir o item não previsto!";
                return;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura o artigo correspondente ao ID na base de dados
                Artigo artigo = db.DBArtigos.FirstOrDefault(a => a.Id == artigoId);


                ItemPrevisto itemExistentePrevisto = db.DBItensCompra.OfType<ItemPrevisto>()
                        .FirstOrDefault(i => i.ArtigoId == artigoId && i.CompraId == compraDevolvida.Id);

                if (itemExistentePrevisto != null)
                {
                    mensagem = "Artigo já adicionado!";
                    return;
                }


                //Caso não encontre
                if (artigo == null)
                {
                    mensagem = "Artigo não encontrado!";
                    return;
                }


                //Confirma que a compra ainda existe na BD (evitar qualquer situação que dê erros)
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == compraDevolvida.Id);

                //Caso ocorra um erro e a compra já não esteja na base de dados
                if (compra == null)
                {
                    mensagem = "Um erro ocorreu! Volte à página principal e volte a selecionar a compra";
                    return;
                }


                //Impede duplicados: o mesmo artigo não pode ser adicionado duas vezes à mesma compra
                ItemNaoPrevisto itemExistente = db.DBItensCompra.OfType<ItemNaoPrevisto>()
                .FirstOrDefault(i => i.ArtigoId == artigoId && i.CompraId == compraDevolvida.Id);



                //Se for existente não adiciona
                if (itemExistente != null)
                {
                    mensagem = "Artigo já adicionado, basta editá-lo!";
                    return;
                }

                //Se não for, cria um item não previsto

                ItemNaoPrevisto item = new ItemNaoPrevisto
                {
                    CompraId = compraDevolvida.Id,
                    ArtigoId = artigoId,
                    Quantidade = quantidade,
                    PrecoUnitario = artigo.Preco,
                    Observacoes = descricao 
                };


                db.DBItensCompra.Add(item);     // adiciona o item à base de dados
                db.SaveChanges();               //Salva alterações

                //Confirma ao utilizador o sucesso da ação
                mensagem = "Item adicionado com sucesso!";

                //Atualiza a label do total gasto com o valor do artigo adicionado
                AdicionarItensNaoPrevistosForm.labelValorTotal.Text = "Total da compra: " + (ControllerCompras.ObterTotalGastoCompra(compraDevolvida.Id)).ToString() + "€";
            }
        }



        //Carrega na DataGridView todos os itens da compra (previstos + não previstos)
        public static void MostrarListaItens(DataGridView datasource)
        {
            //ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Lista itens previstos
                var previstos = db.DBItensCompra.OfType<ItemPrevisto>()
                    .Where(o => o.CompraId == compraDevolvida.Id)
                    .Select(o => new
                    {
                        o.ArtigoId,
                        Artigo = o.Artigo.Nome,
                        Tipo = "Previsto",
                        o.QuantPrevista,
                        o.Quantidade,
                        o.PrecoUnitario,
                        Total = o.PrecoUnitario * o.QuantPrevista,
                        Observacoes = ""                                     // como fazemos concat, ambas listas tem que ter as mesmas propriedades
                    }).ToList();

                //lista itens não previstos
                var naoPrevistos = db.DBItensCompra.OfType<ItemNaoPrevisto>()
                    .Where(o => o.CompraId == compraDevolvida.Id)
                    .Select(o => new
                    {
                        o.ArtigoId,
                        Artigo = o.Artigo.Nome,
                        Tipo = "Não Previsto",
                        QuantPrevista = 0,
                        o.Quantidade,
                        o.PrecoUnitario,
                        Total = o.PrecoUnitario * o.Quantidade,
                        o.Observacoes
                    }).ToList();

                //concatena as duas listas numa só para mostrar na grelha
                var todos = previstos.Concat(naoPrevistos).ToList();

                datasource.DataSource = todos; 
            }
        }



        //Preenche a ComboBox com os tipos de artigo disponíveis
        public static void CarregarTiposArtigo(ComboBox comboBox)
        {
            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {

                var tiposArtigo = db.DBTipoArtigos
                              .OrderBy(t => t.Id).ToList();

                comboBox.DataSource = tiposArtigo;
                comboBox.DisplayMember = "Nome";  // O que o utilizador usa para a seleção
                comboBox.ValueMember = "Id";     // Valor associado
            }
        }



        //Preenche a ComboBox com os artigos do tipo selecionado
        public static void CarregarArtigos(ComboBox comboBox, int tipoArtigoSelecionado)
        {
            //proteção contra a comboBox não inicializada
            if (comboBox == null)
            {
                MessageBox.Show("Erro a carregar artigos! Tente novamente!");
                return;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Vai carregar os artigos do tipo de artigo selecionado
                //E ordena pelo nome
                var artigo = db.DBArtigos.Where(t => t.TipoArtigoId == tipoArtigoSelecionado)
                             .OrderBy(t => t.Nome).ToList();    

                comboBox.DataSource = artigo;
                comboBox.DisplayMember = "Nome";  // O que o utilizador usa para a seleção
                comboBox.ValueMember = "Id";     // Valor associado
            }
        }



        //Altera a quantidade de um item não previsto (Identificado pelo ArtigoID) na compra atual
        public static void AlterarQuantidade(string itemId, int quantidade, out string mensagem)
        {
            int idItem;

            mensagem = "";

            //Validação para garantir que ainda existe a compra
            if (compraDevolvida == null)
            {
                mensagem = "Um erro ocorreu! Volte à página principal e volte a selecionar a compra";
                return;
            }

            //o utilizador tem de inserir o ID do artigo que pretende alterar
            if (itemId == "")
            {
                mensagem = "Insira um ID!";
                return;
            }

            //o ID tem de ser numérico
            if (!int.TryParse(itemId, out idItem))
            {
                mensagem = "Insira um Id numérico!";
                return;
            }

            //A quantidade tem de ser positiva
            if (quantidade <= 0)
            {
                mensagem = "A quantidade tem que ser maior que 0";
                return;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                // Procura o item pelo ArtigoId dentro da compra atual.
                ItemNaoPrevisto item = db.DBItensCompra.OfType<ItemNaoPrevisto>().FirstOrDefault(
                                         i => i.ArtigoId == idItem && i.CompraId == compraDevolvida.Id);

                if (item == null)  //Validação para não selecionarem um item que não existe
                {
                    mensagem = "Insira um item existente!";
                    return;
                }

                //Atualiza a quantidade
                else
                {
                    item.Quantidade = quantidade;
                }

                //Confirma ao utilizador do sucesso e salva as alterações na base de dados
                mensagem = "Quantidade alterado com sucesso";
                db.SaveChanges();
            }

            //Atualiza a label do total da compra com o novo valor do item não previsto
            AdicionarItensNaoPrevistosForm.labelValorTotal.Text = "Total da compra: " + (ControllerCompras.ObterTotalGastoCompra(compraDevolvida.Id)).ToString() + "€";

        }



        //Elimina um item não previsto (identificado pelo ID do Item) da compra atual
        public static void EliminarItem(string itemId, out string mensagem)
        {
            mensagem = "";
            int idItem;

            //Validação para garantir que ainda existe a compra
            if (compraDevolvida == null)
            {
                mensagem = "Um erro ocorreu! Volte à página principal e volte a selecionar a compra";
                return;
            }

            //Validação se o utilizador inseriu um ID
            if (itemId == "")
            {
                mensagem = "Insira um ID!";
                return;
            }

            //O ID tem de ser numérico
            if (!int.TryParse(itemId, out idItem))
            {
                mensagem = "Insira um Id numérico!";
                return;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura o item pelo ArtigoID dentro da compra atual.
                ItemNaoPrevisto item = db.DBItensCompra.OfType<ItemNaoPrevisto>().FirstOrDefault(
                                    i => i.ArtigoId == idItem && i.CompraId == compraDevolvida.Id);

                //Se o item existir remove-o
                if (item != null)
                {
                    db.DBItensCompra.Remove(item);

                }

                //Validação, só remove o item se ele existir
                else
                {
                    mensagem = "Insira um item existente!";
                    return;
                }

                //Salva as alterações e atualiza a BD
                db.SaveChanges();
                mensagem = "Item removido com sucesso!"; //Confirma ao utilizador do sucesso da ação

            }


            //Atualiza o Total Gasto 
            AdicionarItensNaoPrevistosForm.labelValorTotal.Text = "Total da compra: " + (ControllerCompras.ObterTotalGastoCompra(compraDevolvida.Id)).ToString() + "€";

        }
    }
}
