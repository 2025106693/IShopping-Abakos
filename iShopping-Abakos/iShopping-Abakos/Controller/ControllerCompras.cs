using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerCompras
    {
        public static void VoltarPaginaPrincipal()
        {
            ComprasForm.instance.Close();
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
        }

        public static void MostrarCompras(DataGridView dataSource)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                dataSource.DataSource = db.DBCompras.OrderBy(c => c.DataCriacao).ToList();
            }

        }

        public static void CriarCompra(string nomeCompra, string descricao, out string mensagem)
        {
            mensagem = "";

            if (nomeCompra == "")
            {
                mensagem = "Precisa de inserir o campo nome compra!";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.DBCompras.FirstOrDefault(c => c.NomeCompra == nomeCompra);

                if (compra == null)
                {
                    compra = new Compra()
                    {
                        NomeCompra = nomeCompra,
                        Descricao = descricao,
                        DataCriacao = DateTime.Now,
                        CriadoPor = Sessao.UtilizadorAtual,
                        Fechado = false,
                        TotalGasto = 0
                    };

                    db.DBCompras.Add(compra);
                    mensagem = "Compra adicionada com sucesso!";
                }
                else
                {
                    mensagem = "Compra existente, introduza um nome diferente!";
                    return;
                }
                db.SaveChanges();
            }

        }

        public static void EditarInformacoesCompra(string id, string nomeCompra, string descricao, out string mensagem)
        {
            mensagem = "";
            int idCompra;

            if (!int.TryParse(id, out idCompra))
            {
                mensagem = "O id tem de ser numérico!";
                return;

            }

            if ((nomeCompra == "") && (descricao == ""))
            {
                mensagem = "Tem de introduzir informações para realizar a alteração!";
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra);

                if (compra == null)
                {
                    mensagem = "Compra inexistente, selecione uma compra!";
                    return;
                }

                else
                {
                    compra.NomeCompra = nomeCompra;
                    compra.Descricao = descricao;
                    compra.AlteradoPor = Sessao.UtilizadorAtual;
                    compra.DataAlteracao = DateTime.Today;

                    db.SaveChanges();
                    mensagem = "Compra alterada com sucesso!";
                }
                ;
            }
        }

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
                }

                else
                {
                    mensagem = "Introduza uma compra existente";
                    return;
                }
            }
        }
    }
}
