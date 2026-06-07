using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System.Data.Entity;
using System.IO;
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


        // Exportar CSV



        public static void BotaoExportarCSV()
        {
            //Cria a janela de seleção do local onde o ficheiro será guardado
            SaveFileDialog sfd = new SaveFileDialog();

            //Define o filtro para permitir apenas ficheiros CSV
            sfd.Filter = "Ficheiros CSV (*.csv)|*.csv";

            //Define o título da janela
            sfd.Title = "Guardar ficheiro CSV";

            //Define o nome inicial sugerido para o ficheiro
            sfd.FileName = "Compra_.csv";  // nome com o Id

            //Verifica se o utilizador selecionou um local e carregou em Guardar
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //Exporta os dados para o ficheiro selecionado
                ExportarCsv(sfd.FileName);
                
                //Informa o utilizador que a exportação foi concluída
                MessageBox.Show("Ficheiro CSV exportado com sucesso.");
            }
        }

        // <- garante que tens este using no topo

        private static void ExportarCsv(string caminho)
        {
            //Ligação à base de dados
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
                    //Informa o utilizador da inexistência de dados
                    MessageBox.Show("Não existem compras fechadas para exportar!");
                    return;
                }

                //Cria o ficheiro CSV no caminho indicado
                using (StreamWriter sw = new StreamWriter(caminho, false, System.Text.Encoding.UTF8))
                {
                    //Escreve a linha de cabeçalho do ficheiro CSV
                    sw.WriteLine("NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario");

                    //Percorre todas as compras
                    foreach (Compra c in compras)
                    {
                        // se esta compra não tem itens, salta para a próxima
                        if (c.ItensCompra == null || c.ItensCompra.Count == 0)
                        {
                            continue;
                        }

                        //Converte a data de criação para o formato legível
                        string dataCriacao = c.DataCriacao.ToString("dd/MM/yyyy HH:mm:ss");

                        //Inicializa a data de fecho
                        string dataFecho = "";

                        //Caso exista a data de fecho, converte-a para texto
                        if (c.DataFecho.HasValue)
                        {
                            dataFecho = c.DataFecho.Value.ToString("dd/MM/yyyy HH:mm:ss");
                        }

                        //Percorre todos os itens da compra atual
                        foreach (ItemCompra item in c.ItensCompra)
                        {
                            //Valore por defeito
                            string artigoPrevisto = "Não";
                            string artigoNaoPrevisto = "Não";
                            int quantidadePrevista = 0;

                            //Verifica se o item é do tipo previsto
                            if (item is ItemPrevisto ip)
                            {
                                artigoPrevisto = "Sim";
                                quantidadePrevista = ip.QuantPrevista;
                            }

                            //Verifica se o item é do tipo não previsto
                            else if (item is ItemNaoPrevisto)
                            {
                                artigoNaoPrevisto = "Sim";
                            }

                            //Escreve uma linha no ficheiro CSV com os dados do item
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
            //Caso o valor seja nulo devolve uma string vazia
            if (valor == null)
            {
                return "";
            }

            //Verifica se o texto contém caracteres especiais do formato CSV
            if (valor.Contains(";") || valor.Contains("\""))
            {
                //Escapa aspas duplas e envolve o texto entre aspas
                return "\"" + valor.Replace("\"", "\"\"") + "\"";
            }

            //Devolve o texto original caso não necessite de tratamento
            return valor;
        }
    }
}
