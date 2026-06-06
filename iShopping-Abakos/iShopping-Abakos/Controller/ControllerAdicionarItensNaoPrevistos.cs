using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerAdicionarItensNaoPrevistos
    {
        public static Compra compraDevolvida;

        public static void AbrirItensNaoPrevistosForm(Compra compra)
        {
            if (compra == null)
            {
                return;
            }
            else
            {
                compraDevolvida = compra;
                VisualizarCompraForm.instance.Hide();
                AdicionarItensNaoPrevistosForm form = new AdicionarItensNaoPrevistosForm();
                AdicionarItensNaoPrevistosForm.labelNome.Text = compra.NomeCompra;
                AdicionarItensNaoPrevistosForm.labelValorTotal.Text = "Total da compra: " + (ControllerCompras.ObterTotalGastoCompra(compraDevolvida.Id)).ToString() + "€";
                form.ShowDialog();
            }
        }


        public static void AdicionarItemNaoPrevisto(int artigoId, int quantidade, string descricao, out string mensagem)
        {
            mensagem = "";

            if (quantidade <= 0)
            {
                mensagem = "A quantidade tem que ser maior que 0!";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Artigo artigo = db.DBArtigos.FirstOrDefault(a => a.Id == artigoId);

                if (artigo == null)
                {
                    mensagem = "Artigo não encontrado!";
                    return;
                }

                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == compraDevolvida.Id);

                if (compra == null)
                {
                    mensagem = "Compra não encontrada!";
                    return;
                }

                ItemNaoPrevisto itemExistente = db.DBItensCompra.OfType<ItemNaoPrevisto>()
                        .FirstOrDefault(i => i.ArtigoId == artigoId && i.CompraId == compraDevolvida.Id);

                if (itemExistente != null)
                {
                    mensagem = "Artigo já adicionado, basta editá-lo!";
                    return;
                }



                ItemNaoPrevisto item = new ItemNaoPrevisto
                {
                    CompraId = compraDevolvida.Id,
                    ArtigoId = artigoId,
                    Quantidade = quantidade,
                    PrecoUnitario = artigo.Preco,
                    Descricao = descricao
                };


                db.DBItensCompra.Add(item);
                db.SaveChanges();
                mensagem = "Item adicionado com sucesso!";

                AdicionarItensNaoPrevistosForm.labelValorTotal.Text = "Total da compra: " + (ControllerCompras.ObterTotalGastoCompra(compraDevolvida.Id)).ToString() + "€";
            }
        }


        public static void MostrarListaItens(DataGridView datasource)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                //lista itens previstos
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
                        Descricao = ""                                     // como fazemos concat, ambas listas tem que ter as mesmas propriedades
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
                        o.Descricao
                    }).ToList();

                //concatena as duas listas
                var todos = previstos.Concat(naoPrevistos).ToList();

                datasource.DataSource = todos;
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

        public static void CarregarArtigos(ComboBox comboBox, int tipoArtigoSelecionado)
        {

            using (IShoppingContext db = new IShoppingContext())
            {

                var artigo = db.DBArtigos
                              .Where(t => t.TipoArtigoId == tipoArtigoSelecionado)
                              .OrderBy(t => t.Nome).
                              ToList();

                comboBox.DataSource = artigo;
                comboBox.DisplayMember = "Nome";  // o que o utilizador vê
                comboBox.ValueMember = "Id";// valor associado fica escondigo
            }
        }

        public static void AlterarQuantidade(string itemId, int quantidade, out string mensagem)
        {
            int idItem;

            mensagem = "";

            if (itemId == "")
            {
                mensagem = "Insira um ID!";
                return;
            }

            if (!int.TryParse(itemId, out idItem))
            {
                mensagem = "Insira um Id numérico!";
                return;
            }

            if (quantidade <= 0)
            {
                mensagem = "A quantidade tem que ser maior que 0";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                ItemNaoPrevisto item = db.DBItensCompra.OfType<ItemNaoPrevisto>().FirstOrDefault(
                                         i => i.ArtigoId == idItem && i.CompraId == compraDevolvida.Id);

                if (item == null)  // validacao para nao escreverem um id inexistente
                {
                    mensagem = "Insira um item existente!";
                    return;
                }
                else
                {
                    item.Quantidade = quantidade;
                }


                mensagem = "Quantidade alterado com sucesso";
                db.SaveChanges();
            }

            AdicionarItensNaoPrevistosForm.labelValorTotal.Text = "Total da compra: " + (ControllerCompras.ObterTotalGastoCompra(compraDevolvida.Id)).ToString() + "€";

        }

        public static void EliminarItem(string itemId, out string mensagem)
        {
            mensagem = "";
            int idItem;

            if (itemId == "")
            {
                mensagem = "Insira um ID!";
                return;
            }

            if (!int.TryParse(itemId, out idItem))
            {
                mensagem = "Insira um Id numérico!";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {

                ItemNaoPrevisto item = db.DBItensCompra.OfType<ItemNaoPrevisto>().FirstOrDefault(
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

            AdicionarItensNaoPrevistosForm.labelValorTotal.Text = "Total da compra: " + (ControllerCompras.ObterTotalGastoCompra(compraDevolvida.Id)).ToString() + "€";

        }
    }
}
