using iShopping_Abakos;
using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerPaginaInicial
    {

        public static void AbrirFormOrcamentos()
        {

            //escondemos o principal, damos conceal ao user
            // se fosse close, a aplicação termina automaticamente
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            OrcamentosForm Form = new OrcamentosForm();
            Form.ShowDialog();
            
        }

   
        public static void AbrirFormArtigos()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            ArtigosForm Form = new ArtigosForm();
            Form.ShowDialog();
        }

        public static void AbrirFormCompras()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            ComprasForm Form = new ComprasForm();
            Form.ShowDialog();
        }

        public static void AbrirFormEstatisticas()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            EstatisticasForm Form = new EstatisticasForm();
            Form.ShowDialog();
        }
        public static void AbrirFormTipoArtigo()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            TipoArtigoForm Form = new TipoArtigoForm();
            Form.ShowDialog();
        }

        /*public static void AbrirFormVisualizar()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            VisualizarCompraForm Form = new VisualizarCompraForm();
            Form.ShowDialog();
        }*/

        public static Orcamento DevolverOrcamentoAtual()
        {
            string mesAtual = DateTime.Today.ToString("MMMM");
            int anoAtual = DateTime.Today.Year;
            

            using (IShoppingContext db = new IShoppingContext())
            {
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(
                    o => o.Mes == mesAtual && o.Ano == anoAtual);


                return orcamento;
            }

        }

        public static void MostrarEstadoCompras(int estado, DataGridView dataSource)
        {
            if (estado == 0)
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    dataSource.DataSource = db.DBCompras.OrderBy(c => c.Id).ToList();

                }

                
            }
            else if (estado == 1)
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    dataSource.DataSource = db.DBCompras.Where(c => c.Fechado == false).OrderBy(c => c.Id).ToList();
                }
            }
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


            if (id == "")
            {
                MessageBox.Show("Por favor insira um Id");
                return null;
            }

            if (!int.TryParse(id, out idCompra))
            {
                MessageBox.Show("O Id tem de ser numérico");
                return null;
            }


            using (IShoppingContext db = new IShoppingContext())
            {
                Compra compra = db.DBCompras.FirstOrDefault(c => c.Id == idCompra);

                if (compra != null)
                {
                    return compra;
                }
                else
                {
                    MessageBox.Show("Selecione uma compra existente!");
                    return null;
                }
            }
        }


        // Exportar CSV



        public static void BotaoExportarCSV()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Ficheiros CSV (*.csv)|*.csv";
            sfd.Title = "Guardar ficheiro CSV";
            sfd.FileName = "Compra_.csv";  // nome com o Id

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportarCsv(sfd.FileName);
                MessageBox.Show("Ficheiro CSV exportado com sucesso.");
            }
        }

        // <- garante que tens este using no topo

        private static void ExportarCsv(string caminho)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                // só compras fechadas, com itens e artigos carregados
                var compras = db.DBCompras
                    .Include(c => c.ItensCompra.Select(i => i.Artigo))
                    .Where(c => c.Fechado)
                    .OrderBy(c => c.Id)
                    .ToList();

                // se não houver nenhuma compra fechada, avisa e sai
                if (compras.Count == 0)
                {
                    MessageBox.Show("Não existem compras fechadas para exportar!");
                    return;
                }

                using (StreamWriter sw = new StreamWriter(caminho, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario");

                    foreach (Compra c in compras)
                    {
                        // se esta compra não tem itens, salta para a próxima
                        if (c.ItensCompra == null || c.ItensCompra.Count == 0)
                        {
                            continue;
                        }

                        string dataCriacao = c.DataCriacao.ToString("dd/MM/yyyy HH:mm:ss");
                        string dataFecho = "";
                        if (c.DataFecho.HasValue)
                        {
                            dataFecho = c.DataFecho.Value.ToString("dd/MM/yyyy HH:mm:ss");
                        }

                        foreach (ItemCompra item in c.ItensCompra)
                        {
                            string artigoPrevisto = "Não";
                            string artigoNaoPrevisto = "Não";
                            int quantidadePrevista = 0;

                            if (item is ItemPrevisto ip)
                            {
                                artigoPrevisto = "Sim";
                                quantidadePrevista = ip.QuantPrevista;
                            }
                            else if (item is ItemNaoPrevisto)
                            {
                                artigoNaoPrevisto = "Sim";
                            }

                            sw.WriteLine(
                                EscaparCsv(c.NomeCompra) + ";" +
                                dataCriacao + ";" +
                                dataFecho + ";" +
                                EscaparCsv(item.Artigo.Nome) + ";" +
                                artigoPrevisto + ";" +
                                artigoNaoPrevisto + ";" +
                                quantidadePrevista + ";" +
                                item.Quantidade + ";" +
                                item.PrecoUnitario
                            );
                        }
                    }
                }
            }
        }
        private static string EscaparCsv(string valor)
        {
            if (valor == null)
            {
                return "";
            }

            if (valor.Contains(";") || valor.Contains("\""))
            {
                return "\"" + valor.Replace("\"", "\"\"") + "\"";
            }

            return valor;
        }
    }
}
