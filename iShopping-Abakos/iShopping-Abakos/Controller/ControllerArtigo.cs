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
    internal class ControllerArtigo
    {
        public static void VoltarPaginaPrincipal()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
            ArtigosForm.instance.Close();
        }

        public static void botaoAdicionar(string nome, string preco, string descricao, string tipoArtigo)
        {

            decimal precoArtigo;
           

            if (!decimal.TryParse(preco, out precoArtigo))
            {
                MessageBox.Show("O preco tem de ser numerico");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Artigo artigo = db.DBArtigos.FirstOrDefault(
                    o => o.Nome == nome);

                if (artigo == null)
                {
                    artigo = new Artigo()
                    {
                        Nome = nome,
                        Preco = precoArtigo,
                        Descricao = descricao,
                        TipoArtigo = tipoArtigo
                    };
                    db.DBArtigos.Add(artigo);
                }
                else
                {
                    MessageBox.Show("Já existe este artigo!\nSe quiser alterar, clique no botão Editar Artigo");
                    return;
                }

                db.SaveChanges();
                MessageBox.Show("Artigo criado com sucesso!");
            }
        }


        public static void CarregarTiposArtigo(ComboBox comboBox)
        {
            using (IShoppingContext db = new IShoppingContext())
            {

                // para debug usar a DBOrcamentos em baixo

                var tiposArtigo = db.DBTipoArtigos
                              .Select(t => t.Nome)
                              .OrderBy(n => n)
                              .ToList();

                comboBox.DataSource = tiposArtigo;
            }
        }

        public static void MostrarTabelaArtigos(DataGridView dataSource)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                dataSource.DataSource = db.DBArtigos.OrderBy(
                    o => o.Id).ToList();

            }

        }
    }
}
