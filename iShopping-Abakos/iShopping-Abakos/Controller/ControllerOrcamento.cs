using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerOrcamento
    {

        //Fecha o formulário atual e Volta a abrir a página principal
        //lógica recorrente
        public static void VoltarPaginaPrincipal()
        {

            OrcamentosForm.formOrcamento.Close();

            //A Label do Valor do orcamento refere-se ao valor ainda disponível
            //ou seja da diferença do valor do orçamento - totalGasto de Compras Fechadas

            //Por questões de estética 

            var diferenca = DevolverDiferencaOrcamento();

            if (diferenca != 0) // se já existir um orçamento altera, se não mantem a view default
            {
                PaginaInicialForm.label.Text = DevolverDiferencaOrcamento().ToString();
            }

            PaginaInicialForm.instanciaPaginaPrincipal.Show();

        }
        public static void AdicionarOrcamento(string valorText, object mesItem, string anoText)
        {
            int ano;
            decimal valor;

            //Valida se o utilizador inseriu um valor
            if (valorText == "")
            {
                MessageBox.Show("Tem de inserir um valor para o orçamento");
                return;
            }

            //Valida se o valor introduzido é numérico
            if (!decimal.TryParse(valorText, out valor))
            {
                MessageBox.Show("O valor tem de ser numérico");
                return;
            }

            //Verifica se um mês foi selecionado
            if (mesItem == null)
            {
                MessageBox.Show("Selecione um mês");
                return;
            }

            //Verifica se um ano foi inserido
            if(anoText == "")
            {
                MessageBox.Show("Tem de inserir um ano!");
                return;
            }

            //Valida se o ano introduzido é numérico
            if (!int.TryParse(anoText, out ano))
            {
                MessageBox.Show("O ano tem de ser numérico");
                return;
            }

            //Garante que o valor do orçamento é maior que 0
            if (valor <= 0)
            {
                MessageBox.Show("O valor deve ser superior a zero.");
                return;
            }

            string mes = mesItem.ToString();

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura se já existe um orçamento para o mês e ano inseridos
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(o => o.Mes == mes && o.Ano == ano);

                //Caso não existe, cria um novo orçamento
                if (orcamento == null)
                {
                    orcamento = new Orcamento()
                    {
                        Mes = mes,
                        Ano = ano,
                        Valor = valor,
                        DataCriacao = DateTime.Now,
                        CriadoPor = Sessao.UtilizadorAtual
                    };

                    db.DBOrcamentos.Add(orcamento); //adiciona
                }

                //Se existir . . .
                else
                {
                    MessageBox.Show("Já existe um orçamento para este mês!\nSe quiser alterar, clique no botão Editar Orçamento");
                    return;
                }

                //Guarda as alterações na base de dados
                db.SaveChanges();
                MessageBox.Show("Orçamento criado com sucesso!");
            }
        }


        //Devolve o valor restante do orçamento do mês atual
        public static decimal DevolverDiferencaOrcamento()
        {

            //Obtém o mês e o ano Atual
            string mesAtual = DateTime.Today.ToString("MMMM");
            int anoAtual = DateTime.Today.Year;

            decimal diferenca;

            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura o orçamento correspondente ao mês e ano atual
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(
                          o => o.Mes == mesAtual && o.Ano == anoAtual);

                // Caso não exista orçamento (por algum motivo), devolve zero
                if (orcamento == null)
                {
                    return 0;
                }

                //Calcula o total gasto nas compras fechadas do mês atual
                var compras = db.DBCompras.Where(c => c.DataFecho.Value.Year == DateTime.Today.Year && c.DataFecho.Value.Month == DateTime.Today.Month).ToList().Sum(c => c.TotalGasto);

                //Calcula a diferença entre o orçamento e compras feitas
                if (compras != 0)
                {
                    diferenca = orcamento.Valor - compras;
                }
                else
                {
                    diferenca = orcamento.Valor;
                }

                return diferenca;
            }
        }

        //Devolve o orçamento correspondente ao mês e ano atuais
        public static Orcamento DevolverOrcamentoAtual()
        {
            //Obtém o ano e o mês atual
            string mesAtual = DateTime.Today.ToString("MMMM");
            int anoAtual = DateTime.Today.Year;

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Vai procurar o orçamento atual com base no ano e no mês atual
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(
                          o => o.Mes == mesAtual && o.Ano == anoAtual);

                //Validação caso seja nulo, devolve na mesma pois a ação/mensagem depois do erro pode variar
                if (orcamento == null)
                {
                    return null;
                }

                return orcamento; // devolve o orçamento
            }
        }

        //Apresenta todos os orçamentos na tabela
        //Ordenados pelo ano (descendente (atual para o mais antigo) e pelo mês (ascendente (Janeiro, Fevereiro...)
        public static void MostrarTabelaOrçamentos(DataGridView dataSource)
        {
            var meses = DevolverIntMesCorrespondente(); //obtém a conversão do Mês extenso para inteiro

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {

                dataSource.DataSource = db.DBOrcamentos.ToList().OrderByDescending(o => o.Ano)
                                        .ThenBy(o => meses[o.Mes]).ToList();

                //Usam-se o .ToList logo após o DB.Orcamentos para carregar os dados para memória
                //Pois o SQL não conhece a conversão feita e o dicionário
            }
        }

        //Conversão do mês em extenso para inteiro para ordenações
        public static Dictionary<string, int> DevolverIntMesCorrespondente()
        {
            Dictionary<string, int> meses = new Dictionary<string, int>
                {
                    { "Janeiro", 1 },
                    { "Fevereiro", 2 },
                    { "Março", 3 },
                    { "Abril", 4 },
                    { "Maio", 5 },
                    { "Junho", 6 },
                    { "Julho", 7 },
                    { "Agosto", 8 },
                    { "Setembro", 9 },
                    { "Outubro", 10 },
                    { "Novembro", 11 },
                    { "Dezembro", 12 }
                };

            return meses;
        }

        //Altera o orçamento atual
        public static void AlterarOrcamentoAtual(string id, string valorText, DataGridView dataSource)
        {
            decimal valor;
            int id_orcamento;

            //Valida se o utilizador inseriu um valor
            if (valorText == "")
            {
                MessageBox.Show("Tem de inserir um valor para o orçamento");
                return;
            }

            //Valida se o valor é numérico
            if (!decimal.TryParse(valorText, out valor))
            {
                MessageBox.Show("O valor tem de ser numérico!");
                return;
            }

            //Valida se o ID é numérico
            if (!int.TryParse(id, out id_orcamento))
            {
                MessageBox.Show("O ID tem de ser numérico!");
                return;
            }

            //Ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //Procura o orçamento através do ID inserido
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(o => o.Id == id_orcamento);

                //Caso exista  . . . 
                if (orcamento != null)
                {
                    //Atualiza os dados do orçamento
                    orcamento.Valor = valor;
                    orcamento.AlteradoPor = Sessao.UtilizadorAtual;
                    orcamento.DataAlteracao = DateTime.Today;


                }

                //Caso não exista . . .
                else
                {
                    MessageBox.Show("ID do orçamento não encontrado!");
                    return;
                }

                //Salva as alterações na base de dados
                db.SaveChanges();
                MessageBox.Show("Orçamento alterado com sucesso!");

                MostrarTabelaOrçamentos(dataSource); //Atualiza a vista da DataGridView
            }
        }

        // função usada para apagar os campos preenchidos no fim de qualquer Adicionar, Alterar ou Remover
        // foi passado apenas o nome das textbox portanto aqui atribuimos aos parâmetros do tipo TextBox
        public static void LimparCampos(TextBox valor, ComboBox mes, TextBox ano, DataGridView dataSource)
        {
            valor.Text = "";             // coloca os campos a vazio
            mes.SelectedIndex = -1;
            ano.Text = "";
            dataSource.ClearSelection(); // para retirar a selecao do cursor da tabela (datagridview)
        }

        //Função para atualizar labels baseado no orçamento atual e data atual
        public static void AtualizarLabels(Label labelMes, Label labelvalor)
        {
            //Obtém o orçamento atual
            Orcamento orcamento = ControllerOrcamento.DevolverOrcamentoAtual();

            //Caso haja um orçamento definido muda as labels
            if (orcamento != null)
            {
                labelMes.Text = "Mês: " + orcamento.Mes;
                labelvalor.Text = orcamento.Valor.ToString() + "€";
            }

            //Senão fica com a informação default
            else
            {
                labelMes.Text = "Mês: " + DateTime.Today.ToString("MMMM");
                labelvalor.Text = " - - - - ";
            }
        }

        public static void EliminarOrcamento(string id, DataGridView  dataSource, out string mensagem)
        {
            int idOrcamento;

            if(id == "")
            {
                mensagem = "Por favor indique o id da compra a alterar";
                return;

            }else if(!int.TryParse(id, out idOrcamento))
            {
                mensagem = "O valor tem de ser numérico";
                return;
            }

            using(IShoppingContext db = new IShoppingContext())
            {
                var orcamentoEliminar = db.DBOrcamentos.FirstOrDefault(o => o.Id == idOrcamento);

                if(orcamentoEliminar != null)
                {
                    db.DBOrcamentos.Remove(orcamentoEliminar);
                    db.SaveChanges();
                    mensagem = "Orcamento eliminado com sucesso";
                    MostrarTabelaOrçamentos(dataSource); //Atualiza a vista da DataGridView
                }
                else
                {
                    mensagem = "Orcamento não encontrado, por favor indique um orcamento existente";
                }
            }    
        }
    }
}
