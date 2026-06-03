using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerAdicionarItensPrevistos
    {
        public static Compra compraDevolvida;
        public static void AbrirAdicionarItensPrevistosForm(Compra compra)
        {
            if (compra == null)
            {
                return;
            }
            else
            {
                compraDevolvida = compra;
                ComprasForm.instance.Hide();
                AdicionarItensPrevistosForm form = new AdicionarItensPrevistosForm();
                AdicionarItensPrevistosForm.labelNome.Text = compra.NomeCompra;
                AdicionarItensPrevistosForm.labelPrevisto.Text = "Total Previsto: " + (ControllerCompras.ObterTotalPrevisto(compraDevolvida.Id)).ToString() + "€";
                form.ShowDialog();
            }
        }

        public static void AdicionarItemPrevisto( int artigoId, int qtdPrevista, out string mensagem)
        {
            mensagem = "";

            if (qtdPrevista <= 0)
            {
                mensagem = "A quantidade tem de ser maior que 0!";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Artigo artigo = db.DBArtigos.FirstOrDefault(a => a.Id == artigoId);
                if (artigo == null) { mensagem = "Artigo não encontrado!"; return; }

                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == compraDevolvida.Id);
                if (compra == null) { mensagem = "Compra não encontrada!"; return; }
                if (compra.Fechado) { mensagem = "A compra está fechada!"; return; }

                ItemPrevisto item = new ItemPrevisto
                {
                    CompraId = compraDevolvida.Id,
                    ArtigoId = artigoId,
                    QuantPrevista = qtdPrevista,
                    Quantidade = 0,              // ainda não adquiriu
                    PrecoUnitario = artigo.Preco
                };

               
                db.DBItensCompra.Add(item);
                db.SaveChanges();
                mensagem = "Item adicionado com sucesso!";
                 
                AdicionarItensPrevistosForm.labelPrevisto.Text = "Total Previsto: " + (ControllerCompras.ObterTotalPrevisto(compraDevolvida.Id)).ToString() + "€";


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



    }
}
