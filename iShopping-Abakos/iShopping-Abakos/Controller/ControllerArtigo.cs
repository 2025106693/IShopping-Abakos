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

        public static void botaoAdicionar(string nome, string preco, string descricao, int tipoArtigo)
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
                        TipoArtigoId = tipoArtigo,
                        
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


        // Devolve os objetos do tipo TiposArtigo para listar na Combox
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

        public static void MostrarTabelaArtigos(DataGridView dataSource)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                var artigos = db.DBArtigos
            .OrderBy(o => o.Id)
            .Select(o => new
            {
                o.Id,
                o.Nome,
                o.Preco,
                o.Descricao,
                // IdTipoArtigo e TipoArtigo é o nome da coluna que aparece
                IdTipoArtigo = o.TipoArtigo.Id,
                TipoArtigo = o.TipoArtigo.Nome   // aqui aparece o nome em vez do Id
            })
            .ToList();

                dataSource.DataSource = artigos;

            }

        }
    }
}
