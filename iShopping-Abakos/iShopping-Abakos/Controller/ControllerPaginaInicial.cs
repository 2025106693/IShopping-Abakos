using iShopping_Abakos;
using iShopping_Abakos.Model;
using iShopping_Abakos.View;
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

        public static void AbrirFormOrcamentos(PaginaInicialForm formPrincipal)
        {

            //escondemos o principal, damos conceal ao user
            // se fosse close, a aplicação termina automaticamente
            formPrincipal.Hide(); 
            OrcamentosForm Form = new OrcamentosForm();
            Form.ShowDialog();  
        }

        //restantes botões
        public static void AbrirFormAdicionarItens()
        {

            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            AdicionarItensForm Form = new AdicionarItensForm();
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

        public static void AbrirFormVisualizar()
        {
            PaginaInicialForm.instanciaPaginaPrincipal.Hide();
            VisualizarCompraForm Form = new VisualizarCompraForm();
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
