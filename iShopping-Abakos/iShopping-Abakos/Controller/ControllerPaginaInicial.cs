using iShopping_Abakos;
using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            OrcamentosForm Form = new OrcamentosForm();
            Form.ShowDialog();  
        }

        public static Orcamento MostrarOrcamento()
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
    }
}
