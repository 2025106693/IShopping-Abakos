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
        public static void VoltarPaginaPrincipal()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
            TipoArtigoForm.tipoArtigoForm.Close();
        }


        public static void AdicionarTipoArtigo(string nome, string descricao)
        {
            if (nome == "")
            {
                MessageBox.Show("Insira um nome.");
                return;
            }


            // descricao não é obrigatório


            using (IShoppingContext db = new IShoppingContext())
            {
                TipoArtigo tipoArtigo = db.DBTipoArtigos.FirstOrDefault(o => o.Nome == nome);

                if (tipoArtigo == null)
                {
                    tipoArtigo = new TipoArtigo()
                    {
                        Nome = nome
                    };

                    db.DBTipoArtigos.Add(tipoArtigo);
                }
                else
                {
                    MessageBox.Show("Já existe esse tipo de artigo criado!");
                    return;
                }

                db.SaveChanges();
            }
        }



        public static void MostrarTabelaTipoArtigo(DataGridView dataSource)
        {
            using(IShoppingContext db = new IShoppingContext())
            {
                dataSource.DataSource = db.DBTipoArtigos.OrderBy(o => o.Id).ToList();
            }
        }


        public static void AlterarTipoArtigo(string id, string nome, string descricao, DataGridView dataSource)
        {
            int id_tipoArtigo;

            if(nome == "")
            {
                MessageBox.Show("Insira um nome");
                return;
            }

            if(!int.TryParse(id, out id_tipoArtigo))
            {
                MessageBox.Show("O valor tem de ser numérico");
                return;
            }

            
            using (IShoppingContext db = new IShoppingContext())
            {
                TipoArtigo tipoArtigo = db.DBTipoArtigos.FirstOrDefault(o => o.Id == id_tipoArtigo);

                if(tipoArtigo != null)
                {
                    tipoArtigo.Nome = nome;
                    tipoArtigo.Descricao = descricao;
                }
                else
                {
                    MessageBox.Show("ID do Tipo de Artigo não encontrado!");
                    return;
                }

                db.SaveChanges();
                MessageBox.Show("Tipo de Artigo alterado com sucesso");
                MostrarTabelaTipoArtigo(dataSource);
            }
        }
    }
}
