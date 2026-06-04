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
            Orcamento orcamento = DevolverOrcamentoAtual();
            // PaginaInicialForm.label.Text = orcamento.Valor.ToString();
            PaginaInicialForm.instanciaPaginaPrincipal.Show();
            
        }
        public static void AdicionarOrcamento(string valorText, string mes, string anoText)
        {
            int ano;
            decimal valor;
            

            if(!decimal.TryParse(valorText, out valor))
            {
                MessageBox.Show("O valor tem de ser numérico");
                return;
            }

            if (mes == "")
            {
                MessageBox.Show("Selecione um mês");
                return;
            }

            if (!int.TryParse(anoText, out ano))
            {
                MessageBox.Show("O ano tem de ser numérico");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(o => o.Mes == mes && o.Ano == ano);

                if(orcamento == null)
                {
                    orcamento = new Orcamento()
                    {
                        Mes = mes,
                        Ano = ano,
                        Valor = valor,
                        DataCriacao = DateTime.Now,
                        CriadoPor = Sessao.UtilizadorAtual
                    };

                    db.DBOrcamentos.Add(orcamento);
                }
                else
                {
                    MessageBox.Show("Já existe um orçamento para este mês!\nSe quiser alterar, clique no botão Editar Orçamento");
                    return;
                }

                    db.SaveChanges();
                MessageBox.Show("Orçamento criado com sucesso!");
            }  
        }   

        public static Orcamento DevolverOrcamentoAtual()
        {
            string mesAtual = DateTime.Today.ToString("MMMM", new System.Globalization.CultureInfo("pt-PT"));
            int anoAtual = DateTime.Today.Year;


            using (IShoppingContext db = new IShoppingContext())
            {
                Orcamento orcamento = db.DBOrcamentos.FirstOrDefault(
                    o => o.Mes == mesAtual && o.Ano == anoAtual);

              
                return orcamento;
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
