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

                //Se for ultrapassado notifica o utilizador e remove o item da tabela e salva as alterações
                else
                {
                    db.DBItensCompra.Remove(item);
                    mensagem = "Reveja o planeamento das suas compras!";
                    db.SaveChanges();
                }
            }
        }

        public static void MostrarListaItens(DataGridView datasource)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                //restringir a vista apenas com os campos sem aparecer o artigo e compra vazios
                var itensCompra = db.DBItensCompra.OfType<ItemPrevisto>()
                    .Where(o => o.CompraId == compraDevolvida.Id)
                    .OrderBy(o => o.ArtigoId)
                    .Select(o => new
                    {
                        o.ArtigoId,
                        Artigo = o.Artigo.Nome,
                        o.QuantPrevista,
                        o.PrecoUnitario,
                        TotalPrevisto = o.QuantPrevista * o.PrecoUnitario
                    }).ToList();

                datasource.DataSource = itensCompra;
            }
        }

        public static void CarregarTiposArtigo(ComboBox comboBox)
        {
            using (IShoppingContext db = new IShoppingContext())
            {

                var tiposArtigo = db.DBTipoArtigos
                              .OrderBy(t => t.Id).ToList();

                comboBox.DataSource = tiposArtigo;
                comboBox.DisplayMember = "Nome";  // o que o utilizador vê
                comboBox.ValueMember = "Id";// valor associado fica escondigo
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

        public static void AlterarQuantidade(string itemPrevistoId, int quantidade, out string mensagem)
        {
            int idItem;

            mensagem = "";

            if (itemPrevistoId == "")
            {
                mensagem = "Insira um ID!";
                return;
            }

            if (!int.TryParse(itemPrevistoId, out idItem))
            {
                mensagem = "Insira um Id numérico!";
                return;
            }

            if (quantidade == 0 && quantidade < 0)
            {
                mensagem = "A quantidade tem de ser um número maior que 0";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                ItemPrevisto item = db.DBItensCompra.OfType<ItemPrevisto>().FirstOrDefault(
                                         i => i.ArtigoId == idItem && i.CompraId == compraDevolvida.Id);

                if (item == null)
                {
                    mensagem = "Insira um item existente!";
                    return;
                }
                else
                {
                    item.QuantPrevista = quantidade;
                }


                mensagem = "Quantidade alterado com sucesso";
                db.SaveChanges();
            }

            AdicionarItensPrevistosForm.labelPrevisto.Text = "Total Previsto: " + (ControllerCompras.ObterTotalPrevisto(compraDevolvida.Id)).ToString() + "€";

        }

        public static void EliminarItem(string itemPrevistoId, out string mensagem)
        {
            mensagem = "";
            int idItem;

            if (itemPrevistoId == "")
            {
                mensagem = "Insira um ID!";
                return;
            }

            if (!int.TryParse(itemPrevistoId, out idItem))
            {
                mensagem = "Insira um Id numérico!";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {

                ItemPrevisto item = db.DBItensCompra.OfType<ItemPrevisto>().FirstOrDefault(
                                    i => i.ArtigoId == idItem && i.CompraId == compraDevolvida.Id);

                if (item != null)
                {
                    db.DBItensCompra.Remove(item);

                }

                else
                {
                    mensagem = "Insira um item existente!";
                    return;
                }


                db.SaveChanges();
                mensagem = "Item removido com sucesso!";

            }

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