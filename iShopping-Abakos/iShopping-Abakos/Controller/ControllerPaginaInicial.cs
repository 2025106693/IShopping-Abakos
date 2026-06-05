using iShopping_Abakos;
using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerPaginaInicial
    {

        public static void AbrirFormOrcamentos()
        {

            //esconde a página principal, damos conceal ao user
            //se fosse close, a aplicação termina automaticamente 
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();

            //Abre o formulário de compras
            OrcamentosForm Form = new OrcamentosForm();
            Form.ShowDialog();
            
        }

        //Mesma lógica aplicada a todos os botões que abrem um form

        //Abre o Form dos Artigos
        public static void AbrirFormArtigos()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            ArtigosForm Form = new ArtigosForm();
            Form.ShowDialog();
        }

        //Abre o Form das Compras
        public static void AbrirFormCompras()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            ComprasForm Form = new ComprasForm();
            Form.ShowDialog();
        }

        //Abre o Form das Estatisticas
        public static void AbrirFormEstatisticas()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            EstatisticasForm Form = new EstatisticasForm();
            Form.ShowDialog();
        }

        //Abre o Form dos Tipos de Artigo
        public static void AbrirFormTipoArtigo()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            TipoArtigoForm Form = new TipoArtigoForm();
            Form.ShowDialog();
        }
        public static void MostrarEstadoCompras(int estado, DataGridView dataSource)
        {
            // 0 = Todas as compras
            if (estado == 0)
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    dataSource.DataSource = db.DBCompras.OrderBy(c => c.Id).ToList();

                } 
            }

            // 1 = Compras abertas
            else if (estado == 1)
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    dataSource.DataSource = db.DBCompras.Where(c => c.Fechado == false).OrderBy(c => c.Id).ToList();
                }
            }

            // 2 = Compras fechadas
            else if (estado == 2)
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    dataSource.DataSource = db.DBCompras.Where(c => c.Fechado == true).OrderBy(c => c.Id).ToList();
                }
            }
        }

        public static Compra DevolverCompra(string id)
        {
            int idCompra;

            //Verifica se foi introduzido um ID (método de seleção de compra)
            if (id == "")
            {
                MessageBox.Show("Por favor insira um Id");
                return null;
            }

            //Verifica se o ID é numérico
            if (!int.TryParse(id, out idCompra))
            {
                MessageBox.Show("O Id tem de ser numérico");
                return null;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura a compra pelo ID
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra);
                
                if (compra != null)
                {
                    return compra;
                }

                //caso não exista a compra correspondente ao ID inserido
                else
                {
                    MessageBox.Show("Selecione uma compra existente!");
                    return null;
                }
            }
        }
    }
}
