using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerOrcamento
    {
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
    }
}
