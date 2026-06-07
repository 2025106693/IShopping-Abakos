using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System.Linq;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    //Controller responsável pela gestão dos itens Previstos de uma compra
    internal class ControllerAdicionarItensPrevistos
    {
        //Guarda a compra que está a ser editada e é partilhada entre todos os métodos
        public static Compra compraDevolvida;

        //Recebemos a compra do Form anterior respetiva ao ID que o utilizador inseriu
        public static void AbrirAdicionarItensPrevistosForm(Compra compra)
        {
            //a compra é preenchida com o parâmetro passado do form anterior 
            compraDevolvida = compra;

            //Caso a compra não seja válida não deixa avançar nem adicionar itens
            if (compra == null)
            {
                return;
            }

            //Se correr tudo bem . . .
            else
            {

                //O formulário das compras é escondido
                ComprasForm.instance.Hide();

                //Abre o Formulário que permite gerir os itens previstos na compra selecionada
                AdicionarItensPrevistosForm form = new AdicionarItensPrevistosForm();

                //Atualiza a label do nome e do total previsto (total dos itens previstos) da compra selecionada
                AdicionarItensPrevistosForm.labelNome.Text = compra.NomeCompra;
                AdicionarItensPrevistosForm.labelPrevisto.Text = "Total Previsto: " + ControllerCompras.ObterTotalPrevisto(compra.Id).ToString() + "€";

                //Abre o form já com todas as informações necessárias
                form.ShowDialog();
            }
        }

        //Método responsável por adicionar itens previstos
        public static void AdicionarItemPrevisto(int artigoId, int qtdPrevista, out string mensagem)
        {
            mensagem = "";

            //Garante que existe uma compra selecionada
            //Caso o método seja chamado antes de o formulário ser aberto
            //Evita que a compraDevolvida.Id rebente com NullReferenceException
            if (compraDevolvida == null)
            {
                mensagem = "A seleção da compra foi perdida volte à pagina anterior e volte a selecionar!";
                return;
            }

            //a ComboBox de artigos tem de ter algo selecionado.
            if (artigoId <= 0)
            {
                mensagem = "Selecione um artigo!";
                return;
            }


            //Validação a quantidade tem de ser positiva
            if (qtdPrevista <= 0)
            {
                mensagem = "A quantidade tem de ser maior que 0!";
                return;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura o artigo correspondente ao ID indicado
                Artigo artigo = db.DBArtigos.FirstOrDefault(a => a.Id == artigoId);

                //Verifica se o artigo existe 
                if (artigo == null)
                {
                    mensagem = "Artigo não encontrado!";
                    return;
                }

                //Procura a compra selecionada
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == compraDevolvida.Id);

                //Verifica se a compra existe
                if (compra == null)
                {
                    mensagem = "Compra não encontrada!";
                    return;
                }

                //Verifica se a compra está fechada
                if (compra.Fechado)
                {
                    mensagem = "A compra está fechada!";
                    return;
                }

                //Verifica se o artigo já foi adicionado à compra
                ItemPrevisto itemExistente = db.DBItensCompra.OfType<ItemPrevisto>()
                        .FirstOrDefault(i => i.ArtigoId == artigoId && i.CompraId == compraDevolvida.Id);

                //verifica se já existe um artigo existente
                if (itemExistente != null)
                {
                    mensagem = "Artigo já adicionado, basta editá-lo!";
                    return;
                }

                //Cria um novo item previsto
                    ItemPrevisto item = new ItemPrevisto
                    {
                        CompraId = compraDevolvida.Id,
                        ArtigoId = artigoId,
                        QuantPrevista = qtdPrevista,
                        Quantidade = 0,              // ainda não adquiriu
                        PrecoUnitario = artigo.Preco
                    };

                //Adiciona à tabela Itens Compra
                db.DBItensCompra.Add(item);

                //Salva as alterações na bd
                db.SaveChanges();

                //Verifica se o orçamento é ultrapassado com a adição do artigo
                if (VerificarOrcamentoNaoUltrapassado())
                {
                    mensagem = "Item adicionado com sucesso!";
                    AdicionarItensPrevistosForm.labelPrevisto.Text = "Total Previsto: " + ControllerCompras.ObterTotalPrevisto(compra.Id).ToString() + "€";
                }

                //Se for ultrapassado notifica o utilizador
                //remove o item da tabela e salva as alterações
                else
                {
                    db.DBItensCompra.Remove(item);
                    mensagem = "Reveja o planeamento das suas compras!";
                    db.SaveChanges();
                }
            }
        }

        //Apresenta na DataGridView os itens previstos da compra selecionada
        public static void MostrarListaItens(DataGridView datasource)
        {
            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Obtém os itens previstos da compra selecionada
                var itensCompra = db.DBItensCompra.OfType<ItemPrevisto>()
                    .Where(o => o.CompraId == compraDevolvida.Id)
                    .OrderBy(o => o.ArtigoId)

                    //Seleciona apenas os campos a apresentar na DataGridView
                    .Select(o => new
                    {
                        o.ArtigoId,
                        Artigo = o.Artigo.Nome,
                        o.QuantPrevista,
                        o.PrecoUnitario,

                        //Calcula o custo total previsto para cada artigo
                        TotalPrevisto = o.QuantPrevista * o.PrecoUnitario
                    }).ToList();

                //Atualiza a DataGridView com os itens obtidos
                datasource.DataSource = itensCompra;
            }
        }

        //Carrega todos os tipos de artigo disponíveis na ComboBox
        public static void CarregarTiposArtigo(ComboBox comboBox)
        {
            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Obtém o tipo de artigo ordenados por ID
                var tiposArtigo = db.DBTipoArtigos
                              .OrderBy(t => t.Id).ToList();

                //Associa a lista de tipos à ComboBox
                comboBox.DataSource = tiposArtigo;

                //Nome apresentado ao utilizador
                comboBox.DisplayMember = "Nome";

                //ID associado a cada opção
                comboBox.ValueMember = "Id";
            }
        }

        //Carrega os artigos pertencentes ao tipo selecionado
        public static void CarregarArtigos(ComboBox comboBox, int tipoArtigoSelecionado)
        {
            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Obtém os artigos do tipo selecionado
                var artigo = db.DBArtigos
                              .Where(t => t.TipoArtigoId == tipoArtigoSelecionado)
                              .OrderBy(t => t.Nome).
                              ToList();

                //Associa a lista à ComboBox
                comboBox.DataSource = artigo;

                //Nome apresentado ao utilizador
                comboBox.DisplayMember = "Nome";  

                //ID associado ao artigo
                comboBox.ValueMember = "Id";
            }
        }

        //Altera a quantidade prevista de um item de compra
        public static void AlterarQuantidade(string itemPrevistoId, int quantidade, out string mensagem)
        {
            int idItem;

            //Inicializa a mensagem de retorno
            mensagem = "";

            //Verifica se foi introduzido por um ID
            if (itemPrevistoId == "")
            {
                mensagem = "Insira um ID!";
                return;
            }

            // Verifica se o ID introduzido é numérico
            if (!int.TryParse(itemPrevistoId, out idItem))
            {
                mensagem = "Insira um Id numérico!";
                return;
            }

            // Valida se a quantidade é superior a zero
            if (quantidade <= 0)
            {
                mensagem = "A quantidade tem de ser um número maior que 0";
                return;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura o item previsto correspondente ao ID indicado
                ItemPrevisto item = db.DBItensCompra.OfType<ItemPrevisto>().FirstOrDefault(
                                         i => i.ArtigoId == idItem && i.CompraId == compraDevolvida.Id);

                //Verifica se o item existe
                if (item == null)
                {
                    mensagem = "Insira um item existente!";
                    return;
                }
                
                //Atualiza a quantidade prevista do item
                else
                {
                    item.QuantPrevista = quantidade;
                }


                //Apresenta a mensagem de sucesso e guarda as alterações na base de dados
                mensagem = "Quantidade alterado com sucesso";
                db.SaveChanges();
            }

            //Atualiza o total previsto apresentado no formulário
            AdicionarItensPrevistosForm.labelPrevisto.Text = "Total Previsto: " + (ControllerCompras.ObterTotalPrevisto(compraDevolvida.Id)).ToString() + "€";

        }

        //remove um item previsto da compra selecionada
        public static void EliminarItem(string itemPrevistoId, out string mensagem)
        {
            //Inicializa a mensagem de retorno
            mensagem = "";

            int idItem;

            //Verifica se foi introduzido um ID
            if (itemPrevistoId == "")
            {
                mensagem = "Insira um ID!";
                return;
            }

            //Verifica se o ID introduzido é numérico
            if (!int.TryParse(itemPrevistoId, out idItem))
            {
                mensagem = "Insira um Id numérico!";
                return;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura o item previsto correspondente ao ID indicado
                ItemPrevisto item = db.DBItensCompra.OfType<ItemPrevisto>().FirstOrDefault(
                                    i => i.ArtigoId == idItem && i.CompraId == compraDevolvida.Id);

                //Verifica se o item existe
                if (item != null)
                {
                    //Remove o item da base de dados
                    db.DBItensCompra.Remove(item);

                }

                else
                {
                    mensagem = "Insira um item existente!";
                    return;
                }

                // Guarda as alterações efetuadas
                db.SaveChanges();
                mensagem = "Item removido com sucesso!";

            }

            //Atualiza o total previsto apresentado no formulário
            AdicionarItensPrevistosForm.labelPrevisto.Text = "Total Previsto: " + (ControllerCompras.ObterTotalPrevisto(compraDevolvida.Id)).ToString() + "€";


        }

        //Verifica se o valor total previsto não ultrapassa o orçamento atual
        public static bool VerificarOrcamentoNaoUltrapassado()
        {
            //Obtém o orçamento atualmente ativo
            decimal verificacaoOrcamento;

            //Caso não exista orçamento definido
            var orcamentoAtual = ControllerOrcamento.DevolverOrcamentoAtual();

            if (orcamentoAtual == null)
            {
                //Avisa o utilizador que não tem nenhum orçamento
                MessageBox.Show("Sem nenhum orçamento atual. Não irá haver controlo de valores!");
                
                return true;
            }

            //Calcula o valor restante disponível
            else if (orcamentoAtual != null)
            {
                decimal totalPrevisto = ControllerCompras.ObterTotalPrevisto(compraDevolvida.Id);
                
                //Calcula o valor restante disponível
                verificacaoOrcamento = orcamentoAtual.Valor - totalPrevisto;

                //Verifica se o orçamento foi ultrapassado
                if (verificacaoOrcamento <= 0)
                {
                    //Avisa ao utilizador que o orçamento foi ultrapassado
                    MessageBox.Show("Orçamento Ultrapassado não pode adicionar o Item!");
                    
                    return false;
                }

            }

            return true;

        }

    }
}