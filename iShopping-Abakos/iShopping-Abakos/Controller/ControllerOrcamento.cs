using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerOrcamento
    {
       
        //criar um método para fechar o form orçamentos e voltar a mostrar a página Principal
        public static void VoltarPaginaPrincipal()
        {

            OrcamentosForm.formOrcamento.Close();
            PaginaInicialForm.label.Text = DevolverDiferencaOrcamento().ToString();
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
            
        }
        public static void AdicionarOrcamento(string valorText, ComboBox mes, string anoText, out string mensagem)
        {
            int ano;
            decimal valor;
            string mesDevolvido;


            if (valorText == "")
            {
                mensagem = "Insira um valor";
                return;
            }
            else if (!decimal.TryParse(valorText, out valor))
            {
                mensagem = "O valor tem de ser numérico";
                return;
            }


            if (mes.SelectedItem == null)
            {
                mensagem = "Por favor, escolha um mês";
                return;  
            }


            mesDevolvido = mes.SelectedItem.ToString();


            if(anoText == "")
            {
                mensagem = "Insira o ano";
                return;
            }
            else if (!int.TryParse(anoText, out ano))
            {
                mensagem = "O ano tem de ser numérico";
                return;
            }

            

            using (IShoppingContext db = new IShoppingContext())
            {
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(o => o.Mes == mesDevolvido && o.Ano == ano);

                if(orcamento == null)
                {
                    orcamento = new Orcamento()
                    {
                        Mes = mesDevolvido,
                        Ano = ano,
                        Valor = valor,
                        DataCriacao = DateTime.Now,
                        CriadoPor = Sessao.UtilizadorAtual
                    };

                    db.DBOrcamentos.Add(orcamento);
                }
                else
                {
                    mensagem = "Já existe um orçamento para este mês!\nSe quiser alterar, clique no botão Editar Orçamento";
                    return;
                }

                db.SaveChanges();
                mensagem = "Orçamento criado com sucesso!";
            }  
        }   


        public static decimal DevolverDiferencaOrcamento()
        {

            string mesAtual = DateTime.Today.ToString("MMMM");
            int anoAtual = DateTime.Today.Year;
            decimal diferenca;

            using (IShoppingContext db = new IShoppingContext())
            {
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(
                    o => o.Mes == mesAtual && o.Ano == anoAtual);

                var compras = db.DBCompras.Where(c => c.DataFecho.Value.Year == DateTime.Today.Year && c.DataFecho.Value.Month == DateTime.Today.Month).ToList().Sum(c => c.TotalGasto);


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



        public static void DevolverOrcamentoAtual()
        {
            string mesAtual = DateTime.Today.ToString("MMMM");
            int anoAtual = DateTime.Today.Year;


            using (IShoppingContext db = new IShoppingContext())
            {
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(
                    o => o.Mes == mesAtual && o.Ano == anoAtual);


                if (orcamento != null)
                {
                    OrcamentosForm.labelMesAtual.Text = "Mês: " + orcamento.Mes;
                    OrcamentosForm.labelValorOrcamentoAtual.Text = orcamento.Valor.ToString() + "€";
                }
                else
                {
                    OrcamentosForm.labelMesAtual.Text = "Mês: ";
                    OrcamentosForm.labelValorOrcamentoAtual.Text = "0.00€";
                }
            }
        }



        public static void MostrarTabelaOrçamentos(DataGridView dataSource)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                dataSource.DataSource = db.DBOrcamentos.OrderBy(
                    o => o.DataCriacao).ToList();

            }
        }



        public static void AlterarOrcamentoAtual(string id, string valorText, DataGridView dataSource)
        {
            decimal valor;
            int id_orcamento;

            if (!decimal.TryParse(valorText, out valor))
            {
                MessageBox.Show("O valor tem de ser numérico!");
                return;
            }

            if (!int.TryParse(id, out id_orcamento))
            {
                MessageBox.Show("O valor tem de ser numérico!");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(o => o.Id == id_orcamento);

                if (orcamento != null)
                {

                    orcamento.Valor = valor;
                    orcamento.AlteradoPor = Sessao.UtilizadorAtual;
                    orcamento.DataAlteracao = DateTime.Today;
                    
                    
                }
                else
                {
                    MessageBox.Show("ID do orçamento não encontrado!");
                    return;
                }

                db.SaveChanges();
                MessageBox.Show("Orçamento alterado com sucesso!");
                MostrarTabelaOrçamentos(dataSource);
            }
        }
    }
}
